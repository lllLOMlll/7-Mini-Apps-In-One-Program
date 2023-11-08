Module EasyCalculatorSub
    Sub easyCalculatorMenu()   'Variables 
        Dim userInput As String
        Dim inputNum1 As String
        Dim num1 As Double
        Dim inputNum2 As String
        Dim num2 As Double

        'Program loop 
        Do

            'Initializing variables
            Dim operationChoice As String

            ' Display title
            displayTitle()

            ' Display menu
            displayMenu()

            ' Get the math operation from the user
            operationChoice = GetOperationChoice()

            ' Ask and validate Number 1
            num1 = ValidadeNumber(vbNewLine & "Please enter the first number: ")

            ' Ask and validate Number 2
            num2 = ValidadeNumber(vbNewLine & "Please enter the second number: ")


            'Calculate and display     
            CalculateAndDisplayResult(operationChoice, num1, num2)


            userInput = PromptForContinuation()
            ' The loop will go in if the user press C
        Loop While userInput = "C"


    End Sub
    ' VALIDATION FUNCTIONS
    Function GetOperationChoice() As String
        Dim operationChoice As String
        Do
            Console.Write("Enter your choice: ")
            operationChoice = Console.ReadLine().ToUpper()

            If operationChoice = "X" Then
                exitTheProgram()
            End If

            If operationChoice = "A" Or operationChoice = "S" Or operationChoice = "M" Or
               operationChoice = "WD" Or operationChoice = "D" Or operationChoice = "MOD" Or
               operationChoice = "POW" Or operationChoice = "E" Then
                Return operationChoice
            Else
                displayMenu()
            End If
        Loop While True
    End Function
    Function ValidadeNumber(prompt As String) As Double
        Dim input As String
        Dim number As Double
        Do
            Console.WriteLine(prompt)
            input = Console.ReadLine().ToUpper()
            If input = "X" Then
                exitTheProgram()
            ElseIf Double.TryParse(input, number) Then
                Return number
            Else
                Console.WriteLine(vbNewLine & "You did not enter a valid input!")
            End If
        Loop
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

    ' MATH FUNCTIONS
    ' Addition
    Function AddNumbers(num1 As Double, num2 As Double) As Double
        Return num1 + num2
    End Function

    ' Susbtraction
    Function SubtractNumbers(num1 As Double, num2 As Double) As Double
        Return num1 - num2
    End Function

    ' Multiplication
    Function MutiplyNumbers(num1 As Double, num2 As Double) As Double
        Return num1 * num2
    End Function

    ' Whole division
    Function WholeDivisionNumber(num1 As Double, num2 As Double) As Double
        Return num1 \ num2
    End Function

    ' Division
    Function DivideNumbers(num1 As Double, num2 As Double) As Double
        Return num1 / num2
    End Function

    ' Modulo
    Function ModuleNumbers(num1 As Double, num2 As Double) As Double
        Return num1 Mod num2
    End Function

    ' Power
    Function PowerNumbers(num1 As Double, num2 As Double) As Double
        Return num1 ^ num2
    End Function

    ' SUB

    ' Display title
    Sub displayTitle()
        Console.WriteLine("***************************************")
        Console.WriteLine("***********MINI CALCULATOR*************")
        Console.WriteLine("***************************************")
    End Sub

    Sub displayMenu()
        Console.WriteLine()
        Console.WriteLine("You can press X at any moment to exit the program")
        Console.WriteLine()
        Console.WriteLine("What do you want to?")
        Console.WriteLine("Choose an operation:")
        Console.WriteLine()
        Console.WriteLine("Addition        : A")
        Console.WriteLine("Substraction    : S")
        Console.WriteLine("Multiplication  : M")
        Console.WriteLine("Whole Division  : WD")
        Console.WriteLine("Division        : D")
        Console.WriteLine("Modulo          : Mod")
        Console.WriteLine("Exponential     : Pow")
        Console.WriteLine("Exit            : X")
        Console.WriteLine()
    End Sub

    ' Display the result
    Sub CalculateAndDisplayResult(operation As String, num1 As Double, num2 As Double)
        Select Case operation
            Case "A"
                Console.WriteLine(vbNewLine & "ADDITION")
                Dim sum As Double = AddNumbers(num1, num2)
                Console.WriteLine("{0} + {1} = {2}", num1, num2, sum)

            Case "S"
                Console.WriteLine(vbNewLine & "SUBTRACTION")
                Dim difference As Double = SubtractNumbers(num1, num2)
                Console.WriteLine("{0} - {1} = {2}", num1, num2, difference)

            Case "M"
                Console.WriteLine(vbNewLine & "MULTIPLICATION")
                Dim product As Double = MutiplyNumbers(num1, num2)
                Console.WriteLine("{0} * {1} = {2}", num1, num2, product)

            Case "WD"
                Console.WriteLine(vbNewLine & "WHOLE DIVISION")
                If num2 = 0 Then
                    Console.WriteLine("You cannot divide by 0")
                Else
                    Dim result As Double = WholeDivisionNumber(num1, num2)
                    Console.WriteLine("{0} \ {1} = {2}", num1, num2, result)
                End If

            Case "D"
                Console.WriteLine(vbNewLine & "DIVISION")
                If num2 = 0 Then
                    Console.WriteLine("You cannot divide by 0")
                Else
                    Dim quotient As Double = DivideNumbers(num1, num2)
                    Console.WriteLine("{0} / {1} = {2}", num1, num2, quotient)
                End If

            Case "MOD"
                Console.WriteLine(vbNewLine & "MODULO")
                Dim modulo As Double = ModuleNumbers(num1, num2)
                Console.WriteLine("{0} modulo {1} = {2}", num1, num2, modulo)

            Case "POW"
                Console.WriteLine(vbNewLine & "EXPONENTIAL")
                Dim power As Double = PowerNumbers(num1, num2)
                Console.WriteLine("{0} ^ {1} = {2}", num1, num2, power)

            Case Else
                Console.WriteLine("Invalid operation.")
        End Select
    End Sub

    ' Exit the program
    Sub exitTheProgram()
        Console.WriteLine()
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine("                             Thanks for using EASY CALCULATOR, a Major Software")
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine(vbNewLine)
        Threading.Thread.Sleep(2000)
        Console.Clear()
        MainMenuSub.mainMenuMenu()
        ' Exit the subroutine easyCalculator
        Return
    End Sub
End Module










