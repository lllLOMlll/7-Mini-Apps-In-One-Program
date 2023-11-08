Module MainMenuSub

    Sub Main()
        mainMenuMenu()

    End Sub

    Sub mainMenuMenu()
        'Loop if the user choice is wrong
        Do
            Console.WriteLine("-------------------------------------------------------------------")
            Console.WriteLine("---------------------------- LAB 3 --------------------------------")
            Console.WriteLine("-------------------------------------------------------------------")
            Console.WriteLine(vbNewLine)

            Console.WriteLine("Those are the choices:")
            Console.WriteLine("1. Easy Calculator")
            Console.WriteLine("2. Average Numbers")
            Console.WriteLine("3. Christmas Tree")
            Console.WriteLine("4. Easy cash Registry")
            Console.WriteLine("5. Lil’ Menu")
            Console.WriteLine("6. Numba2Letters")
            Console.WriteLine("7. Phonebook")
            Console.WriteLine("8. Exit")

            Console.WriteLine(vbNewLine)

            Console.WriteLine("What is your choice? (1 to 8)")
            Dim userChoice As String
            userChoice = Console.ReadLine()

            Select Case userChoice
                Case "1"
                    Console.Clear()
                    easyCalculatorMenu()
                    Exit Do
                Case "2"
                    Console.Clear()
                    averageNumberMenu()
                Case "3"
                    Console.Clear()
                    christmasTreeMenu()
                Case "4"
                    Console.Clear()
                    easyCashRegistryMenu()
                Case "5"
                    Console.Clear()
                    lilMenuMenu()
                Case "6"
                    Console.Clear()
                    numa2LetterMenu()
                Case "7"
                    Console.Clear()
                    phoneBookMenu()
                Case "8"
                    Console.Clear()
                    exitMainProgram()
                Case Else
                    Console.WriteLine(vbNewLine & "Wrong input!")
                    System.Threading.Thread.Sleep(1500)
                    Console.Clear()

            End Select
        Loop

        Console.ReadKey()
    End Sub

    Sub exitMainProgram()
        Console.WriteLine()
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine("                             Thanks for using a MAJOR SOFWARE product. See you soon")
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine(vbNewLine)
        Threading.Thread.Sleep(2000)
        Console.Clear()
        MainMenuSub.mainMenuMenu()
        ' Exit the subroutine easyCalculator
        Return
    End Sub
End Module
