. ./helpers.ps1

Describe "Special Help Items" {
    It "commandbars do not promote combobox" {
        $h = get-help -path dte:/commandbars/menubar new-item -full | out-string
        
        assert { $h -notmatch 'combobox' }
    }
}

Describe "Provider Help" {

    $newitem = @{
        'dte:/solution/projects' = 'new project or solution folder';
        'dte:/commandbars' = 'new command bar';
        'dte:/commandbars/menubar' = 'new control';
        'dte:/debugger/breakpoints' = 'new breakpoint';
        'dte:/Commands' = 'new command';
        'dte:/errors' = 'new error';
        'dte:/outputpanes' = 'new output pane';
        'dte:/Solution\CodeModel' = 'new project or solution folder';
        'dte:/windowconfigurations' = 'new window configuration'

    };

    $newitem.keys | %{
        It "new-item $_" {
            $path = $_;
            $h = get-help -path $_ new-item;
            assert { $h.synopsis -match $newitem[$_]}            
        }
    }

    $setitem = @{
        'WindowConfigurations\Design'= 'updates.+window configuration'

    };

    $setitem.keys | %{
        It "set-item $_" {
            $path = $_;
            $h = get-help -path $_ set-item;
            assert { $h.synopsis -match $setitem[$_]}            
        }
    }

    $invokeitem = @{
    'OutputPanes\Build' = '';
    'WindowConfigurations\Debug' = '';
    'Windows\Output' = ''
    }

    $invokeitem.keys | %{
        It "invoke-item $_" {
            $path = $_;
            $h = get-help -path $_ invoke-item;
            assert { $h.synopsis -match $setitem[$_]}            
        }
    }


    <#
    $sh = get-help new-item;    
    ls dte: -rec | where { $_.ssitemmode -match '\+' } | where { $_ -notmatch 'commandbars' } | select -exp PSPath | %{
        $path = $_ -replace '.+::','';
        It "new item $path" {
            assert{ $sh -ne ( get-help -path $path new-item ) }
        }
    }
    #>
}