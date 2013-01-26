. ./helpers.ps1

Describe "Solution/CodeModel/../<namespace>" {
    
    new-solution;
    new-item dte:/solution/projects/P -type classlibrary -language csharp | out-null;
    new-item dte:/solution/projects/P/C.cs -type class | out-null;
    new-item dte:/solution/codemodel/P/C.cs/N -type namespace | out-null;

    $root = "dte:/solution/codemodel/P/C.cs/N";

    It "new-item namespace" {
        
        verify { new-item -path $root/N1 -type namespace }
        
        assert { test-path $root/N1 }        
    } 

    It "new-item internal class" {
        verify { new-item -path $root -name "MyClass" -type class }

        assert { test-path "$root/MyClass" }
    }

    It "new-item public class" {
        verify { new-item -path $root -name "EveryonesClass" -access public -type class }

        assert { test-path "$root/EveryonesClass" }
    }

    It "new-item delegate" {
        verify { new-item -path $root -name "MyDelegate" -memberType 'void' -type delegate }

        assert { test-path "$root/MyDelegate" }
    }
    
    It "errors on new-item using" {
        assert-error { get-asdfwae } #new-item -path $root -name 'System.IO' -position 0 -type import }
    }    
}