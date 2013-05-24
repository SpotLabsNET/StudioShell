. ./helpers.ps1

Describe "Write-Prompt" {

    $oldPrompt = get-item function:/prompt | select -exp definition    
    
    It "does not output errors" {
        function prompt {
            throw 'asdf';
        }       
        
        $error.clear()
        write-prompt
        assert-true { $error.count -eq 0 }
        
    }

}
