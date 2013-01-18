. ./helpers.ps1

Describe "Solution/Projects" {

    new-solution;

    It "new-item create new projects" {
        $name = get-randomname
        new-item -path dte:/solution/projects/$name -type ClassLibrary | out-null
        test-path dte:/solution/projects/$name
    }
    
    It "new-item create new folders" {
        $name = get-randomname
        new-item dte:/solution/projects/$name -type folder | out-null
        test-path dte:/solution/projects/$name
    }

    It "remove-item existing projects" {
        $name = get-randomname
        new-item dte:/solution/projects -type classlibrary -language csharp -name $name | out-null
        
        assert { test-path dte:/solution/projects/$name }
        
        remove-item dte:/solution/projects/$name -recurse -force;
        
        -not( test-path dte:/solution/projects/$name )
    }

    It "remove-item existing folders" {
        $name = get-randomname
        new-item dte:/solution/projects/$name -type folder | out-null
        assert { test-path dte:/solution/projects/$name }
        remove-item dte:/solution/projects/$name -recurse -force;
        -not( test-path dte:/solution/projects/$name )
    }

    It "get-childitem list project items" {
        $name = get-randomname
        new-item -path dte:/solution/projects/$name -type ClassLibrary | out-null
        $items = dir dte:/solution/projects/$name;
        $items.length -ne 0;        
    }       
}
<#
Describe "Solution/Projects/<folder>" {
    
    new-solution;
    function new-folder {
        $fn = get-randomname;
        new-item -path "dte:/solution/projects/$fn" -type folder | out-null;
        "dte:/solution/projects/$fn"
    }
    
    It "new-item create new subprojects" {
        $name = (get-randomname);
        $folder = new-folder;
        write-debug $folder;    
        arrange {
            new-item -path $folder/$name -type classlibrary
        }
        
        assert {
            test-path "$folder/$name"
        }

    }

    It "new-item create new folders" {
        $name = (get-randomname);
        $folder = new-folder;
        arrange {
            new-item -path $folder -name $name -type folder
        }
        
        assert {
            test-path "$folder/$name"
        }
    }
    
    It "new-item create new class" {
        $name = (get-randomname);
        $folder = new-folder;
        arrange {
            new-item -path $folder -name $name -type 'class'
        }
        
        assert {
            test-path "$folder/$name"
        }
    }

    It "remove-item project items" {
        $name = (get-randomname);
        $folder = new-folder;
        arrange {
            new-item -path $folder -name $name -type 'class'
            assert { test-path "$folder/$name" }
            remove-item -path $folder/$name -recurse -force;
        }
        
        assert {
            -not( test-path "$folder/$name" )
        }
    }
    
    It "should support remove-item for deleting existing folders" {
        $name = (get-randomname);
        $folder = new-folder;
        arrange {
            new-item -path $folder -name $name -type folder
            assert { test-path "$folder/$name" }
            remove-item -path $folder/$name -recurse -force;
        }
        
        assert {
            -not( test-path "$folder/$name" )
        }
    }
}
#>