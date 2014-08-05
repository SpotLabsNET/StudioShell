#
#   Copyright (c) 2014 Code Owls LLC, All Rights Reserved.
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

param( 
    [parameter(valuefrompipeline = $true, mandatory=$true)]
    [type]
    $enumType 
)

process {
    $t = $enumType
    $className = $t.name[0].tostring().toupper() + $t.name.substring(1) 
    new-item -name $className -type class -access public | out-null
    pushd .\$className

    $valueNames = [enum]::getnames($t) 
    $valueNames | foreach { 
        $f = $_; 
        new-item -type property -name $f -return $t.fullname -get -access public | out-null
        
        $s = get-content ./$f; 
        $s = $s -replace "default\($($t.name)\)","$($t.name).$f"; 
        set-content ./$f $s  
    }

    popd
}







