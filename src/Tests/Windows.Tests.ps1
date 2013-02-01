. ./helpers.ps1

Describe "WindowConfigurations" {
    
    delete-solution;

    $root = 'dte:/windows'
    
    It "errors on new-item" {
        $name = (get-randomname 'a');
        
        assert-error { new-item -path $root/$name }
    }

    It "invoke-item focuses window" {
        arrange { 
            ( get-item dte:/windows/output ).Visible = $false; 
            invoke-item dte:/windows/output 
        }
        assert { ( get-item dte:/windows/output ).Visible -eq $true;  }
    }
   
}
