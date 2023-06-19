Imports System
Imports System.Runtime.InteropServices


Namespace SetProxy
    Public Module WinInetInterop
        Public applicationName As String

        <DllImport("wininet.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
        Private Function InternetOpen(ByVal lpszAgent As String, ByVal dwAccessType As Integer, ByVal lpszProxyName As String, ByVal lpszProxyBypass As String, ByVal dwFlags As Integer) As IntPtr
        End Function

        <DllImport("wininet.dll", SetLastError:=True)>
        <MarshalAs(UnmanagedType.Bool)>
        Private Function InternetCloseHandle(ByVal hInternet As IntPtr) As Boolean
        End Function

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
        Private Structure INTERNET_PER_CONN_OPTION_LIST
            Public Size As Integer

            ' The connection to be set. NULL means LAN.
            Public Connection As IntPtr

            Public OptionCount As Integer
            Public OptionError As Integer

            ' List of INTERNET_PER_CONN_OPTIONs.
            Public pOptions As IntPtr
        End Structure
        Private Enum INTERNET_OPTION
            ' Sets or retrieves an INTERNET_PER_CONN_OPTION_LIST structure that specifies
            ' a list of options for a particular connection.
            INTERNET_OPTION_PER_CONNECTION_OPTION = 75

            ' Notify the system that the registry settings have been changed so that
            ' it verifies the settings on the next call to InternetConnect.
            INTERNET_OPTION_SETTINGS_CHANGED = 39

            ' Causes the proxy data to be reread from the registry for a handle.
            INTERNET_OPTION_REFRESH = 37

        End Enum

        Private Enum INTERNET_PER_CONN_OptionEnum
            INTERNET_PER_CONN_FLAGS = 1
            INTERNET_PER_CONN_PROXY_SERVER = 2
            INTERNET_PER_CONN_PROXY_BYPASS = 3
            INTERNET_PER_CONN_AUTOCONFIG_URL = 4
            INTERNET_PER_CONN_AUTODISCOVERY_FLAGS = 5
            INTERNET_PER_CONN_AUTOCONFIG_SECONDARY_URL = 6
            INTERNET_PER_CONN_AUTOCONFIG_RELOAD_DELAY_MINS = 7
            INTERNET_PER_CONN_AUTOCONFIG_LAST_DETECT_TIME = 8
            INTERNET_PER_CONN_AUTOCONFIG_LAST_DETECT_URL = 9
            INTERNET_PER_CONN_FLAGS_UI = 10
        End Enum
        Private Const INTERNET_OPEN_TYPE_DIRECT As Integer = 1  ' direct to net
        Private Const INTERNET_OPEN_TYPE_PRECONFIG As Integer = 0 ' read registry
        ''' <summary>
        ''' Constants used in INTERNET_PER_CONN_OPTON struct.
        ''' </summary>
        Private Enum INTERNET_OPTION_PER_CONN_FLAGS
            PROXY_TYPE_DIRECT = &H00000001   ' direct to net
            PROXY_TYPE_PROXY = &H00000002   ' via named proxy
            PROXY_TYPE_AUTO_PROXY_URL = &H00000004   ' autoproxy URL
            PROXY_TYPE_AUTO_DETECT = &H00000008   ' use autoproxy detection
        End Enum

        ''' <summary>
        ''' Used in INTERNET_PER_CONN_OPTION.
        ''' When create a instance of OptionUnion, only one filed will be used.
        ''' The StructLayout and FieldOffset attributes could help to decrease the struct size.
        ''' </summary>
        <StructLayout(LayoutKind.Explicit)>
        Private Structure INTERNET_PER_CONN_OPTION_OptionUnion
            ' A value in INTERNET_OPTION_PER_CONN_FLAGS.
            <FieldOffset(0)>
            Public dwValue As Integer
            <FieldOffset(0)>
            Public pszValue As IntPtr
            <FieldOffset(0)>
            Public ftValue As ComTypes.FILETIME
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Private Structure INTERNET_PER_CONN_OPTION
            ' A value in INTERNET_PER_CONN_OptionEnum.
            Public dwOption As Integer
            Public Value As INTERNET_PER_CONN_OPTION_OptionUnion
        End Structure
        ''' <summary>
        ''' Sets an Internet option.
        ''' </summary>
        <DllImport("wininet.dll", CharSet:=CharSet.Ansi, SetLastError:=True)>
        Private Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As INTERNET_OPTION, ByVal lpBuffer As IntPtr, ByVal lpdwBufferLength As Integer) As Boolean
        End Function

        ''' <summary>
        ''' Queries an Internet option on the specified handle. The Handle will be always 0.
        ''' </summary>
        <DllImport("wininet.dll", CharSet:=CharSet.Ansi, SetLastError:=True, EntryPoint:="InternetQueryOption")>
        Private Function InternetQueryOptionList(ByVal Handle As IntPtr, ByVal OptionFlag As INTERNET_OPTION, ByRef OptionList As INTERNET_PER_CONN_OPTION_LIST, ByRef size As Integer) As Boolean
        End Function

        ''' <summary>
        ''' Set the proxy server for LAN connection.
        ''' </summary>
        Public Function SetConnectionProxy(ByVal proxyServer As String) As Boolean

            Dim hInternet = InternetOpen(applicationName, INTERNET_OPEN_TYPE_DIRECT, Nothing, Nothing, 0)

            ''' Create 3 options.
            'INTERNET_PER_CONN_OPTION[] Options = new INTERNET_PER_CONN_OPTION[3];

            ' Create 2 options.
            Dim Options = New INTERNET_PER_CONN_OPTION(1) {}

            ' Set PROXY flags.
            Options(0) = New INTERNET_PER_CONN_OPTION()
            Options(0).dwOption = INTERNET_PER_CONN_OptionEnum.INTERNET_PER_CONN_FLAGS
            Options(0).Value.dwValue = INTERNET_OPTION_PER_CONN_FLAGS.PROXY_TYPE_PROXY

            ' Set proxy name.
            Options(1) = New INTERNET_PER_CONN_OPTION()
            Options(1).dwOption = INTERNET_PER_CONN_OptionEnum.INTERNET_PER_CONN_PROXY_SERVER
            Options(1).Value.pszValue = Marshal.StringToHGlobalAnsi(proxyServer)

            ''' Set proxy bypass.
            'Options[2] = new INTERNET_PER_CONN_OPTION();
            'Options[2].dwOption =
            '    (int)INTERNET_PER_CONN_OptionEnum.INTERNET_PER_CONN_PROXY_BYPASS;
            'Options[2].Value.pszValue = Marshal.StringToHGlobalAnsi("local");

            ''' Allocate a block of memory of the options.
            'System.IntPtr buffer = Marshal.AllocCoTaskMem(Marshal.SizeOf(Options[0])
            '    + Marshal.SizeOf(Options[1]) + Marshal.SizeOf(Options[2]));

            ' Allocate a block of memory of the options.
            Dim buffer = Marshal.AllocCoTaskMem(Marshal.SizeOf(Options(0)) + Marshal.SizeOf(Options(1)))

            Dim current = buffer

            ' Marshal data from a managed object to an unmanaged block of memory.
            For i = 0 To Options.Length - 1
                Marshal.StructureToPtr(Options(i), current, False)
                current = CType(CInt(current) + Marshal.SizeOf(Options(i)), IntPtr)
            Next

            ' Initialize a INTERNET_PER_CONN_OPTION_LIST instance.
            Dim option_list As INTERNET_PER_CONN_OPTION_LIST = New INTERNET_PER_CONN_OPTION_LIST()

            ' Point to the allocated memory.
            option_list.pOptions = buffer

            ' Return the unmanaged size of an object in bytes.
            option_list.Size = Marshal.SizeOf(option_list)

            ' IntPtr.Zero means LAN connection.
            option_list.Connection = IntPtr.Zero

            option_list.OptionCount = Options.Length
            option_list.OptionError = 0
            Dim size = Marshal.SizeOf(option_list)

            ' Allocate memory for the INTERNET_PER_CONN_OPTION_LIST instance.
            Dim intptrStruct = Marshal.AllocCoTaskMem(size)

            ' Marshal data from a managed object to an unmanaged block of memory.
            Marshal.StructureToPtr(option_list, intptrStruct, True)

            ' Set internet settings.
            Dim bReturn = InternetSetOption(hInternet, INTERNET_OPTION.INTERNET_OPTION_PER_CONNECTION_OPTION, intptrStruct, size)

            ' Free the allocated memory.
            Marshal.FreeCoTaskMem(buffer)
            Marshal.FreeCoTaskMem(intptrStruct)
            InternetCloseHandle(hInternet)

            ' Throw an exception if this operation failed.
            If Not bReturn Then
                Throw New ApplicationException(" Set Internet Option Failed!")
            End If

            Return bReturn
        End Function




        ''' <summary>
        ''' Backup the current options for LAN connection.
        ''' Make sure free the memory after restoration. 
        ''' </summary>
        Private Function GetSystemProxy() As INTERNET_PER_CONN_OPTION_LIST

            ' Query following options. 
            Dim Options = New INTERNET_PER_CONN_OPTION(2) {}

            Options(0) = New INTERNET_PER_CONN_OPTION()
            Options(0).dwOption = INTERNET_PER_CONN_OptionEnum.INTERNET_PER_CONN_FLAGS
            Options(1) = New INTERNET_PER_CONN_OPTION()
            Options(1).dwOption = INTERNET_PER_CONN_OptionEnum.INTERNET_PER_CONN_PROXY_SERVER
            Options(2) = New INTERNET_PER_CONN_OPTION()
            Options(2).dwOption = INTERNET_PER_CONN_OptionEnum.INTERNET_PER_CONN_PROXY_BYPASS

            ' Allocate a block of memory of the options.
            Dim buffer = Marshal.AllocCoTaskMem(Marshal.SizeOf(Options(0)) + Marshal.SizeOf(Options(1)) + Marshal.SizeOf(Options(2)))

            Dim current = buffer

            ' Marshal data from a managed object to an unmanaged block of memory.
            For i = 0 To Options.Length - 1
                Marshal.StructureToPtr(Options(i), current, False)
                current = CType(CInt(current) + Marshal.SizeOf(Options(i)), IntPtr)
            Next

            ' Initialize a INTERNET_PER_CONN_OPTION_LIST instance.
            Dim Request As INTERNET_PER_CONN_OPTION_LIST = New INTERNET_PER_CONN_OPTION_LIST()

            ' Point to the allocated memory.
            Request.pOptions = buffer

            Request.Size = Marshal.SizeOf(Request)

            ' IntPtr.Zero means LAN connection.
            Request.Connection = IntPtr.Zero

            Request.OptionCount = Options.Length
            Request.OptionError = 0
            Dim size = Marshal.SizeOf(Request)

            ' Query internet options. 
            Dim result = InternetQueryOptionList(IntPtr.Zero, INTERNET_OPTION.INTERNET_OPTION_PER_CONNECTION_OPTION, Request, size)
            If Not result Then
                Throw New ApplicationException(" Set Internet Option Failed! ")
            End If

            Return Request
        End Function

        ''' <summary>
        ''' Restore the options for LAN connection.
        ''' </summary>
        ''' <paramname="request"></param>
        ''' <returns></returns>
        Public Function RestoreSystemProxy() As Boolean

            Dim hInternet = InternetOpen(applicationName, INTERNET_OPEN_TYPE_DIRECT, Nothing, Nothing, 0)

            Dim request As INTERNET_PER_CONN_OPTION_LIST = GetSystemProxy()
            Dim size = Marshal.SizeOf(request)

            ' Allocate memory. 
            Dim intptrStruct = Marshal.AllocCoTaskMem(size)

            ' Convert structure to IntPtr 
            Marshal.StructureToPtr(request, intptrStruct, True)

            ' Set internet options.
            Dim bReturn = InternetSetOption(hInternet, INTERNET_OPTION.INTERNET_OPTION_PER_CONNECTION_OPTION, intptrStruct, size)

            ' Free the allocated memory.
            Marshal.FreeCoTaskMem(request.pOptions)
            Marshal.FreeCoTaskMem(intptrStruct)

            If Not bReturn Then
                Throw New ApplicationException(" Set Internet Option Failed! ")
            End If

            ' Notify the system that the registry settings have been changed and cause
            ' the proxy data to be reread from the registry for a handle.
            InternetSetOption(hInternet, INTERNET_OPTION.INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0)
            InternetSetOption(hInternet, INTERNET_OPTION.INTERNET_OPTION_REFRESH, IntPtr.Zero, 0)

            InternetCloseHandle(hInternet)

            Return bReturn
        End Function

    End Module
End Namespace
