Module AverageNumberSub
    Sub averageNumberMenu()
        ' Declare variables
        Dim userInput As String
        Dim numbersToAverageInput As String
        Dim numbersToAverage As Integer

        ' Loop for the whole program
        Do
            ' Show Title
            ShowTitle()
            ' Tell the user he can press X to exit
            ShowExitOption()

            ' Ask how many numbers the users wants to average         
            numbersToAverage = AskHomManyNumbers("How many numbers do you want to average?")

            ' Asking numbers and calculate total sum
            Dim totalSum As Double = GetNumbersAndCalculateSum(numbersToAverage)

            ' Calculate the average
            Dim displayAverage = Average(totalSum, numbersToAverage)
            Console.WriteLine(vbNewLine & $"The average of your {numbersToAverage} numbers is :" & vbNewLine & displayAverage)


            ' Ask the user if they want to continue or exit
            userInput = PromptForContinuation()
            ' If the user enters "C", the loop will continue
        Loop While userInput = "C"

    End Sub



    ' FUNCTIONS
    Function AskHomManyNumbers(prompt As String) As Double
        Dim numbersToAverageInput As String
        Dim numbersToAverage As Integer
        Do
            Console.WriteLine(prompt)
            numbersToAverageInput = Console.ReadLine()
            ' First, try to parse the input to an integer.
            If Integer.TryParse(numbersToAverageInput, numbersToAverage) Then
                ' If parsing is successful, then check if it's 1 or less.
                If numbersToAverage > 1 Then
                    ' This means it's a number bigger than 1. We can proceed!
                    Return numbersToAverage
                    Exit Do
                End If
                If numbersToAverage <= 1 Then
                    Console.WriteLine(vbNewLine & "We cannot average 1 number, 0 or negative numbers.")
                End If
                ' If parsing is not successful, it means the input wasn't numeric.
            Else
                Console.WriteLine(vbNewLine & "Wrong input. Please enter a positive number")
            End If
        Loop
    End Function

    Function GetNumbersAndCalculateSum(numbersToAverage As Integer) As Double
        Dim numberCount As Integer = 1
        Dim totalSum As Double = 0
        Dim inputNumber As String
        Dim inputNumberParse As Double

        For i = 1 To numbersToAverage
            Do
                Console.WriteLine(vbNewLine & $"Please enter number {numberCount}:")
                inputNumber = Console.ReadLine()
                If Double.TryParse(inputNumber, inputNumberParse) Then
                    totalSum += inputNumberParse
                    Exit Do
                Else
                    Console.WriteLine(vbNewLine & "Wrong input. Please enter a positive number.")
                End If
            Loop
            numberCount += 1
        Next

        Return totalSum
    End Function
    ' Average
    Function Average(totalSum As Double, numbersToAverage As Integer) As Double
        Return totalSum / numbersToAverage
    End Function

    Function PromptForContinuation() As String
        Dim userInput As String
        Do
            Console.WriteLine()
            Console.WriteLine("Do you want to continue?")
            Console.WriteLine("Press 'C' to continue or 'X' to return to the main menu")
            userInput = Console.ReadLine().ToUpper()

            If userInput = "C" Then
                Console.Clear()
                Exit Do
            ElseIf userInput = "X" Then
                exitTheProgram()
            Else
                Console.WriteLine("Invalid input. Please press 'C' to continue or 'X' to return to the main menu.")
            End If
        Loop
        Return userInput
    End Function

    ' SUBS
    ' Title
    Sub ShowTitle()
        Console.WriteLine("***************************************************")
        Console.WriteLine("************* ADDITION AND AVERAGE ****************")
        Console.WriteLine("***************************************************")
    End Sub

    Sub ShowExitOption()
        Console.WriteLine()
        Console.WriteLine("You can press X at any moment to exit the program")
        Console.WriteLine()
    End Sub

    Sub exitAverageNumbers()
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
