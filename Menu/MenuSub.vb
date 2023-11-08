Module MenuSub
    Sub lilMenuMenu()
        'Changing the color of the console
        Console.BackgroundColor = ConsoleColor.DarkBlue
        Console.ForegroundColor = ConsoleColor.White
        Console.Clear()

        ' Initialize an ArrayList with some menu items
        Dim Menu As New ArrayList()

        ' Each menu item is an ArrayList with Name, Price, Rating
        Menu.Add(New ArrayList({"Kebab", "9.99", "5"}))
        Menu.Add(New ArrayList({"Beef", "6.99", "7"}))
        Menu.Add(New ArrayList({"Chicken", "4.00", "9"}))
        Menu.Add(New ArrayList({"Beer", "0.99", "10"}))

        Dim userInput As String

        Do
            ' Print out the menu
            displayTitle()

            For i As Integer = 0 To Menu.Count - 1
                Dim menuItem As ArrayList = Menu(i)
                Console.WriteLine("Item " & i + 1 & ": " & menuItem(0) & vbTab & menuItem(1) & "$" & vbTab & menuItem(2))
            Next

            Console.WriteLine(vbNewLine)
            Console.WriteLine("Do you want to enter a new item? (y/n)")
            userInput = Console.ReadLine()

            If userInput.ToLower() = "y" Then
                ' Function AddNewItem
                If Not AddNewItem(Menu) Then
                    Console.WriteLine("Failed to add new item. Please try again.")
                End If
            ElseIf userInput.ToLower() = "n" Then
                Console.WriteLine("Do you want to exit the program?")
                Console.WriteLine("Press X to exit or any other key to continue")
                Dim exitMenu As String = Console.ReadLine()
                If exitMenu.ToUpper() = "X" Then
                    ' Exit the program
                    exitLilMenu()
                End If
            Else
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.")
            End If

            Console.Clear()
        Loop While userInput.ToLower() <> "x"

        ' Exit message
        Console.WriteLine()
        Console.WriteLine("Thank you for using LIL' MENU. Exiting...")
        Threading.Thread.Sleep(2000)
        Console.Clear()
        ' If MainMenuSub.mainMenuMenu() is a subroutine for the main menu, it should be called here.
        ' MainMenuSub.mainMenuMenu()
    End Sub

    ' ByRef : the variable location itself is copied
    Function AddNewItem(ByRef Menu As ArrayList)
        Dim newItem As New ArrayList()
        Dim name, price, rate As String
        Dim priceDouble As Double
        Dim rateInteger As Integer

        ' Name
        Do
            Console.WriteLine(vbNewLine & "Enter the name of the new item (cannot be empty):")
            name = Console.ReadLine()
            If String.IsNullOrEmpty(name) Then
                Console.WriteLine(vbNewLine & "Wrong input!")
            Else
                newItem.Add(name)
                Exit Do
            End If
        Loop

        ' Price
        Do
            Console.WriteLine(vbNewLine & "Enter the price of the new item (0.99 - 100.00):")
            price = Console.ReadLine()
            If Not (Double.TryParse(price, priceDouble) AndAlso priceDouble >= 0.99 AndAlso priceDouble <= 100) Then
                Console.WriteLine(vbNewLine & "Wrong input")
            Else
                newItem.Add(priceDouble.ToString("F2"))
                Exit Do
            End If
        Loop

        ' Rating
        Do
            Console.WriteLine(vbNewLine & "Enter the rate of the new item (1 - 10):")
            rate = Console.ReadLine()
            If Not (Integer.TryParse(rate, rateInteger) AndAlso rateInteger >= 1 AndAlso rateInteger <= 10) Then
                Console.WriteLine(vbNewLine & "Wrong input")
            Else
                newItem.Add(rateInteger)
                Exit Do
            End If

        Loop


        ' Add the new item to the menu
        Menu.Add(newItem)
        Return True
    End Function

    Sub displayTitle()
        Console.WriteLine("*******************************************************************")
        Console.WriteLine("*************************** MENU **********************************")
        Console.WriteLine("*******************************************************************")
        Console.WriteLine(vbNewLine)

        Console.WriteLine("ITEM #" & vbTab & "NAME" & vbTab & "PRICE" & vbTab & "RATING")
    End Sub
    Sub exitLilMenu()
        Console.WriteLine()
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine("                             Thanks for using LIL' MENU, a Major Software")
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine(vbNewLine)
        Threading.Thread.Sleep(2000)
        Console.Clear()
        MainMenuSub.mainMenuMenu()
        ' Exit the subroutine easyCalculator
        Return
    End Sub
End Module
