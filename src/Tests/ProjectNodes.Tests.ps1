. ./helpers.ps1

Describe "Solution/Projects/<project>" {

    new-solution;
    $project = ( new-project ).pspath;

    It "new-item class file" {
        $name = get-randomname
        new-item -path $project/$name.cs -type class -language csharp | out-null
        assert{test-path $project/$name.cs}
    }   
    
    It "new-item code file" {
        $name = get-randomname
        new-item -path $project/$name.cs -type codefile -language csharp | out-null
        assert{test-path $project/$name.cs}
    }
       
    It "new-item folder" {
        $name = get-randomname
        new-item -path $project/$name -type folder | out-null
        assert{test-path $project/$name}
    }
    
    It "remove-item folder -force" {
        $name = get-randomname
        new-item -path $project/$name -type folder | out-null
        assert{ test-path $project/$name} | out-null
        
        remove-item -path $project/$name -recurse -force;
        
        assert{ -not( test-path $project/$name ) } 
    }   
    
    It "remove-item folder" {
        $name = get-randomname
        new-item -path $project/$name -type folder | out-null
        assert{ test-path $project/$name} | out-null
        
        remove-item -path $project/$name -recurse;
        
        assert{ -not( test-path $project/$name ) } 
    }   
    
    It "remove-item code file" {
        $name = get-randomname
        assert{ new-item -path $project/$name.cs -type codefile -language csharp } | out-null
        
        remove-item $project/$name.cs -recurse;
        assert-false {test-path $project/$name.cs}
    }
    
    It "rename-item project" {
        $name = get-randomname
        
        rename-item $project -newname $name;
        assert { -not( test-path $project ) -and ( test-path dte:/solution/projects/$name ) }
        
    }
    

}

