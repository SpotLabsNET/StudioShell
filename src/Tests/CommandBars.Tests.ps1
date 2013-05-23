. ./helpers.ps1

Describe "CommandBars" {
    
    delete-solution;

    $root = 'dte:/commandbars/menubar/tmp'
        
    It "new-item creates popup menu" {        
        verify { new-item -path $root -type popup }
        
        assert{ test-path -path $root }
    }

    It "new-item creates button" {
        $name = (get-randomname 'MENU');
        verify { new-item -path $root/$name -type button -value { 2+2 } }

        assert{ test-path -path $root/$name }
    }
    
    It "new-item creates button with bindings" {
        $name = (get-randomname 'MENU');
        verify { new-item -path $root/$name -type button -binding 'global::f2' -value { 2+2 } }
        
        assert{ test-path -path $root/$name }
    }
    
    It "new-item creates button with control bindings" {
        $name = (get-randomname 'MENU');
        verify { new-item -path $root/$name -type button -binding 'global::ctrl+f2' -value { 2+2 } }
        
        assert{ test-path -path $root/$name }
    }
    
    It "new-item creates button with alt bindings" {
        $name = (get-randomname 'MENU');
        verify { new-item -path $root/$name -type button -binding 'global::alt+f2' -value { 2+2 } }
        
        assert{ test-path -path $root/$name }
    }
    
    It "new-item creates button with shift bindings" {
        $name = (get-randomname 'MENU');
        verify { new-item -path $root/$name -type button -binding 'global::shift+f2' -value { 2+2 } }
        
        assert{ test-path -path $root/$name }
    }
    
    It "new-item creates button with composite bindings" {
        $name = (get-randomname 'MENU');
        verify { new-item -path $root/$name -type button -binding 'global::alt+ctrl+f2,g' -value { 2+2 } }
        
        assert{ test-path -path $root/$name }
    }
    
    It "new-item creates button as default itemtype" {
        $name = (get-randomname 'MENU');
        verify { new-item -path $root/$name -value { 2+2 } }
        
        assert{ ( get-item -path $root/$name ).type -match 'button' }
    }
 
    It "invoke-item clicks button control" {
        $name = (get-randomname 'MENU');
        $global:testresult = 1;
        
        verify { 
            $a = new-item -path $root/$name -value { $global:testresult = 555; } 
            $a.enabled = $true;
            invoke-item $root/$name;
        }
        
        assert{ $global:testresult -eq 555; }
    }  
}
