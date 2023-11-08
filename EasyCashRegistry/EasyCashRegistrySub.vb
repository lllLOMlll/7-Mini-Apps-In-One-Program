Module EasyCashRegistrySub
    Sub easyCashRegistryMenu()
        Dim totalPrice As Double = 0.0

        Do
            Dim userItemChoice As String
            Dim userItemChoiceInt As Integer
            Dim itemQuantity As String
            Dim itemQuantityDouble As Double
            Dim itemPrice As Double
            Dim item1Price As Double = 10.99
            Dim item2Price As Double = 5.66
            Dim item3Price As Double = 7.65
            Dim item4Price As Double = 8.64
            Dim item5Price As Double = 5.0
            Dim item6Price As Double = 7.2
            Dim item7Price As Double = 10.0

            ' Display the title
            displayTitle()

            ' Tell the use he can press X to exit the program
            tellUserWichKeyToHitToExitTheProgram()

            ' Display the menu
            displayTheMenu()

            ' Ask and validate user choice
            userItemChoiceInt = askAnItemAndValidate("Enter your choice")

            Select Case userItemChoiceInt
                Case 1
                    itemPrice = item1Price
                Case 2
                    itemPrice = item2Price
                Case 3
                    itemPrice = item3Price
                Case 4
                    itemPrice = item4Price
                Case 5
                    itemPrice = item5Price
                Case 6
                    itemPrice = item6Price
                Case 7
                    itemPrice = item7Price
                Case Else
                    Console.WriteLine()
                    Console.WriteLine("Invalid item choice.")
            End Select

            Do
                Console.WriteLine()
                Console.WriteLine("Item {0} price = ${1}", userItemChoiceInt, itemPrice)
                Console.WriteLine("How much of item {0} do you want? (The quantity may vary between 0 and 15)", userItemChoiceInt)
                itemQuantity = Console.ReadLine()
                If itemQuantity.ToUpper() = "X" Then
                    exitEasyCashRegistry()
                ElseIf IsNumeric(itemQuantity) AndAlso (Convert.ToDouble(itemQuantity) >= 0 AndAlso Convert.ToDouble(itemQuantity) <= 15) Then
                    Exit Do
                Else
                    Console.WriteLine()
                    Console.WriteLine("Wrong input! Please enter a number between 0 and 15")
                End If
            Loop

            itemQuantityDouble = Convert.ToDouble(itemQuantity)
            Dim subTotal As Double = CalculateSubTotal(itemQuantityDouble, itemPrice)
            totalPrice = CalculateTotalPrice(totalPrice, subTotal)

            Console.WriteLine()
            Console.WriteLine("You've purchased {0} of item {1}", itemQuantity, userItemChoiceInt)
            Console.WriteLine()
            Console.WriteLine("Price of the current transaction = ${0:0.00}", subTotal)
            Console.WriteLine("Total price of all your purchases = ${0:0.00}", totalPrice)

            Do
                Console.WriteLine()
                Console.WriteLine("Do you want to purchase something else? (Y/N)")
                Dim morePurchase As String = Console.ReadLine().ToUpper()
                If morePurchase = "X" Then
                    exitEasyCashRegistry()
                ElseIf morePurchase = "N" Then
                    Console.Clear()
                    Console.WriteLine("Total price of all your purchases = ${0:0.00}", totalPrice)
                    Console.WriteLine(vbNewLine & "WARNING!" & vbNewLine & "The total price has been reset to 0")
                    totalPrice = 0
                    System.Threading.Thread.Sleep(3000)
                    Console.Clear()
                    Exit Do
                ElseIf morePurchase = "Y" Then
                    Exit Do
                Else
                    Console.WriteLine()
                    Console.WriteLine("Invalid input. Please enter 'Y' for Yes, 'N' for No, or 'X' to exit.")
                End If
            Loop
        Loop
    End Sub





    Function askAnItemAndValidate(promt As String) As Integer
        Console.Write(promt)
        Do
            Dim userItemChoice As String
            Dim userItemChoiceInt As Integer
            userItemChoice = Console.ReadLine().ToUpper()
            If userItemChoice = "X" Then
                exitEasyCashRegistry()
            End If
            If Integer.TryParse(userItemChoice, userItemChoiceInt) AndAlso (userItemChoiceInt >= 1 AndAlso userItemChoiceInt <= 7) Then
                Return userItemChoiceInt
                Exit Do
            Else
                Console.WriteLine()
                Console.WriteLine("You did not enter a valid input!")
                Console.WriteLine("Pleaes choose an item (1 to 7)")
            End If
        Loop
    End Function
    Function CalculateSubTotal(itemQuantityDouble As Double, itemPrice As Double) As Double
        Return itemQuantityDouble * itemPrice
    End Function

    Function CalculateTotalPrice(currentTotal As Double, subtotal As Double) As Double
        Return currentTotal + subtotal
    End Function

    ' SUB
    Sub displayTitle()
        Console.WriteLine("***************************************************")
        Console.WriteLine("************** MINI CASH REGISTER ****************")
        Console.WriteLine("***************************************************")
        Console.WriteLine()
    End Sub

    Sub tellUserWichKeyToHitToExitTheProgram()
        Console.WriteLine("You can press X at any moment to exit the program")
        Console.WriteLine()
    End Sub

    Sub displayTheMenu()
        Dim item1Price As Double = 10.99
        Dim item2Price As Double = 5.66
        Dim item3Price As Double = 7.65
        Dim item4Price As Double = 8.64
        Dim item5Price As Double = 5.0
        Dim item6Price As Double = 7.2
        Dim item7Price As Double = 10.0
        Console.WriteLine("Which item do you want to buy?")
        Console.WriteLine("Enter the number of the item")
        Console.WriteLine("Item 1  :${0:0.00}", item1Price)
        Console.WriteLine("Item 2  :${0:0.00}", item2Price)
        Console.WriteLine("Item 3  :${0:0.00}", item3Price)
        Console.WriteLine("Item 4  :${0:0.00}", item4Price)
        Console.WriteLine("Item 5  :${0:0.00}", item5Price)
        Console.WriteLine("Item 6  :${0:0.00}", item6Price)
        Console.WriteLine("Item 7  :${0:0.00}", item7Price)
        Console.WriteLine()
    End Sub
    ' Exit the program
    Sub exitEasyCashRegistry()
        Console.WriteLine()
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine("                             Thanks for using EASY CASH REGISTRY, a Major Software")
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine(vbNewLine)
        Threading.Thread.Sleep(2000)
        Console.Clear()
        MainMenuSub.mainMenuMenu()
        ' Exit the subroutine easyCalculator
        Return
    End Sub

End Module
