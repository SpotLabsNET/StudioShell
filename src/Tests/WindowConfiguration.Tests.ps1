. ./helpers.ps1

Describe "WindowConfigurations" {
    
    delete-solution;

    $root = 'dte:/windowconfigurations'
    
    It "new-item create new configuration" {
        $name = (get-randomname 'a');
        
        verify {
            new-item -path $root/$name 
        }
        
        assert {
            test-path "$root/$name"
        }
    }

    It "invoke-item recalls existing configuration" {
        $name = get-randomname 'W';

        arrange { ( get-item dte:/windows/output ).Visible = $true; }
        verify { new-item -path $root/$name }

        arrange { 
            ( get-item dte:/windows/output ).Visible = $false; 
            invoke-item -path $root/$name 
        }
        
        assert { ( get-item dte:/windows/output ).Visible }
    }

    It "set-item updates existing configuration" {
        $name = get-randomname 'W';

        arrange { ( get-item dte:/windows/output ).Visible = $true; }
        verify { new-item -path $root/$name }

        arrange { 
            ( get-item dte:/windows/output ).Visible = $false; 
            set-item -path $root/$name;
            ( get-item dte:/windows/output ).Visible = $true;
            invoke-item -path $root/$name;
        }
        
        assert { -not( ( get-item dte:/windows/output ).Visible ) }            
    }

    It "set-item -force creates nonexisting configuration" {
        $name = get-randomname 'r';
        verify { set-item $root/$name -force }
        assert { test-path $root/$name }
    }

    It "remove-item deletes configuration" {
        $name = get-randomname 'zceaef'
        arrange{
            new-item $root/$name;
            test-path $root/$name;
        }

        verify { remove-item $root/$name }

        assert { -not (test-path $root/$name) }
    }

   
    It "errors on set-item for nonexisting configuration" {
        assert-error { new-item "dte:/windowconfigurations/$(get-randomname 'lasf')" } 
    }

    It "errors on new-item for existing configuration" {
        $name = get-randomname 'z';
        arrange { new-item dte:/windowconfigurations/$name }

        assert-error { new-item dte:/windowconfigurations/$name }
    }

    It "errors on remove-item for nonexistent configuration" {
        assert-error { remove-item "dte:/windowconfigurations/$(new-randomname 'CzCz')" }
    }
    
}
