. ./helpers.ps1

Describe "Solution/CodeModel/<project>/<file>" {
    
    new-solution;
    new-item dte:/solution/projects/P -type classlibrary -language csharp | out-null;
    new-item dte:/solution/projects/P/C.cs -type class | out-null;
    
    $root = "dte:/solution/codemodel/P/C.cs";

    It "new-item namespace" {
        
        verify { new-item -path $root/N -type namespace }
        
        assert { test-path $root/N }    
    
    } 

    It "new-item using" {
        verify { new-item -path $root -name 'System.IO' -position 0 -type import }
        assert{ test-path "$root/Import System.IO" }
    }

}