#
#   Copyright (c) 2011 Code Owls LLC, All Rights Reserved.
#
#   Licensed under the Microsoft Reciprocal License (Ms-RL) (the "License");
#   you may not use this file except in compliance with the License.
#   You may obtain a copy of the License at
#
#     http://www.opensource.org/licenses/ms-rl
#
#   Unless required by applicable law or agreed to in writing, software
#   distributed under the License is distributed on an "AS IS" BASIS,
#   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
#   See the License for the specific language governing permissions and
#   limitations under the License.
#

$local:root = $myInvocation.MyCommand.Path | split-path;

# create module commands for each script under the scripts directory
# content of each script file becomes a unique exported module function
write-debug "generating StudioShell.Provider module commands";

ls $local:root/scripts | foreach {
	$local:c = ( get-content -path $_.pspath ) -join "`n";	
	$local:n = $_.Name -replace '.{4}$','';
	
	$local:fxn = "function $local:n`n{`n$local:c`n}";
	
	write-verbose $local:fxn
	invoke-expression $local:fxn;
}
