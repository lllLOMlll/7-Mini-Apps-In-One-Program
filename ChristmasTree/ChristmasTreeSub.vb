Module ChristmasTreeSub
    Sub christmasTreeMenu()
        Dim numStars As Integer
        Dim userChoice As String

        Do
            ' Inform the user that he can press X to exit the program
            InformTheUserOfExitButton()

            ' Function to ask the user how many stars he wants
            numStars = AskAndValidateANumber("How many stars do you want. Please choose a number between 4 and 100.")

            ' Calculate the nearest square root plus 3 to complete the tree
            Dim nearestCompletion As Integer = CalculateNearestCompletion(numStars)
            ' Calculate the number of rows
            Dim numRows As Integer = CInt(Math.Sqrt(nearestCompletion - 3))

            ' Print the Christmas tree
            DisplayTheTree(numRows)

            Console.WriteLine()
                Console.WriteLine($"The nearest completion is: {nearestCompletion}")

            ' Ask user if they want to go again
            DoYouWantToContinue("Press any key to continue. You can press X at any moment to exit the program")

        Loop
    End Sub

    ' FUNCTIONS
    ' Ask and validate a number
    Function AskAndValidateANumber(promt As String) As Integer
        Do
            ' Ask the user the question of the promt (How many stars)
            Console.WriteLine(promt)
            ' Take the answer of the user and make it as the variable 'input'
            Dim input As String = Console.ReadLine()
            Dim numStars As Integer
            ' Check for exit condition
            If input.ToUpper() = "X" Then
                exitChrismasTree()
            End If

            ' Validate the integer input
            If Integer.TryParse(input, numStars) AndAlso numStars >= 4 AndAlso numStars <= 100 Then
                ' Adding a line between input and the tree
                Console.WriteLine()
                Return numStars
            Else
                InvalidInput()
            End If
        Loop
    End Function
    ' Square root
    Function CalculateNearestCompletion(numStars As Integer) As Integer
        ' Square root + 3
        ' CInt = Convert to integer
        Dim numRows As Integer = CInt(Math.Ceiling(Math.Sqrt(numStars)))
        Dim totalStars As Integer = numRows * numRows
        Return totalStars + 3
    End Function



    ' SUB
    Sub InformTheUserOfExitButton()
        Console.WriteLine()
    End Sub

    ' Invalid input
    Sub InvalidInput()
        Console.WriteLine()
        Console.WriteLine("Invalid input. Please enter a number between 4 and 100.")
        Console.WriteLine()
    End Sub

    'Display the tree
    Sub DisplayTheTree(numRows As Integer)
        For i As Integer = 1 To numRows
            ' Print leading spaces
            For j As Integer = 1 To numRows - i
                Console.Write(" ")
            Next
            ' Print stars
            For j As Integer = 1 To 2 * i - 1
                Console.Write("*")
            Next
            ' Move to the next line
            Console.WriteLine()
        Next
    End Sub

    Sub DoYouWantToContinue(promt As String)
        Console.WriteLine()
        Console.WriteLine(promt)
        Dim userChoice As String
        userChoice = Console.ReadLine()
        If userChoice.ToUpper = "X" Then
            exitChrismasTree()
        End If

    End Sub
    Sub exitChrismasTree()
        Console.WriteLine()
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine("                             Thanks for using AVERAGE NUMBERS, a Major Software")
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine(vbNewLine)
        Threading.Thread.Sleep(2000)
        Console.Clear()
        MainMenuSub.mainMenuMenu()
        ' Exit the subroutine easyCalculator
        Return
    End Sub
End Module
