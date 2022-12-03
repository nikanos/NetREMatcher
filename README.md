### NetREMatcher
.NET Regular Expression matching tool

### Command line arguments
  **-i, --input**              Input File (Optional - Default: Standard Input)

  **-o, --output**              Output file (Optional - Default: Standard Output)

  **-p, --patern**              Regular expression pattern

  **-f, --patern-file**         File containing the regular expression pattern

  **-v, --invert-results**      Invert results (return lines **NOT** matching the pattern)

  **-l, --logging-enabled**     Enable logging

  ### Examples
1. Match 3-digit numbers (Reading/writing from/to standard IO)

        NetREMatcher.exe --pattern ^[0-9]$

2. Match anything that is NOT a 3-digit number (Reading/writing from/to standard IO):

        NetREMatcher.exe --pattern ^[0-9]$ --invert-results

3. Match pattern read from file named <pattern.re> and enable logging (Reading/writing from/to standard IO)
 
        NetREMatcher.exe --pattern-file pattern.re --logging-enabled

4. Match pattern read from file named <pattern.re> and enable logging (Reading/writing from/to given files):
 
        NetREMatcher.exe --pattern-file pattern.re --input input.txt --logging-enabled --output output.txt
