Module PhoneBookSub
    Sub phoneBookMenu()
        'Changing the color of the console
        Console.BackgroundColor = ConsoleColor.DarkMagenta
        Console.ForegroundColor = ConsoleColor.White
        Console.Clear()

        ' Initialize an ArrayList
        Dim phoneBook As New ArrayList()

        ' Adding initial entries
        phoneBook.Add(New String() {"Louis", "450-456-7784"})
        phoneBook.Add(New String() {"Victor", "438-113-0023"})
        phoneBook.Add(New String() {"Magalie", "514-111-7854"})
        phoneBook.Add(New String() {"Michel", "514-111-1597"})
        phoneBook.Add(New String() {"Francine", "450-111-5512"})
        phoneBook.Add(New String() {"Jean", "514-111-6482"})
        phoneBook.Add(New String() {"Martin", "514-111-7411"})
        phoneBook.Add(New String() {"Sylvie", "450-111-5531"})

        ' Variable to record the user choice
        Dim userChoice As String

        Do
            ' Display the menu
            displayMenu()


            ' Display the options
            displayOptions()

            userChoice = Console.ReadLine()

            ' Declare the found variable outside the Select Case
            Dim found As Boolean = False

            Select Case userChoice
                ' Add
                Case "1"
                    addUser(phoneBook)

                ' Edit
                Case "2"
                    editUser(phoneBook)


                ' Delete
                Case "3"
                    deleteUser(phoneBook)

                ' Display
                Case "4"
                    displayPhoneBook(phoneBook)

                Case "5" ' Exit
                    exitPhoneBook()

                Case Else
                    Console.WriteLine("Invalid option.")
            End Select


        Loop While userChoice <> "5"
    End Sub
    ' FUNCTIONS
    ' Add user
    Function addUser(ByRef phoneBook As ArrayList)
        Dim newName As String = ""
        Dim newNumber As String = ""
        Console.WriteLine()
        Console.WriteLine("- ADDING AN ENTRY TO THE PHONEBOOK -")
        Console.WriteLine("Enter the name:")
        newName = Console.ReadLine()
        ' Validate name
        Do While String.IsNullOrEmpty(newName)
            Console.WriteLine("Enter the name:")
            newName = Console.ReadLine()
            If String.IsNullOrEmpty(newName) Then
                Console.WriteLine("Name cannot be empty.")
            End If
        Loop


        ' Validate phone number
        Dim isValid As Boolean = False
        Do While Not isValid
            Console.WriteLine()
            Console.WriteLine("Enter the phone number in the format (XXX-XXX-XXXX):")
            newNumber = Console.ReadLine()
            ' Regex ^ = start  d{3} = 3 numbers   $ = end
            If System.Text.RegularExpressions.Regex.IsMatch(newNumber, "^\d{3}-\d{3}-\d{4}$") Then
                isValid = True
            Else
                Console.WriteLine("Invalid phone number format.")
            End If
        Loop

        ' Add new entry
        phoneBook.Add({newName, newNumber})
        Console.WriteLine()
        Console.WriteLine(newName & " was added to the phone book.")

        'Waiting 2 seconds and then clear the console
        System.Threading.Thread.Sleep(2000)
        Console.Clear()
    End Function

    ' Edit user
    Function editUser(ByRef phoneBook As ArrayList)
        Console.WriteLine()
        Console.WriteLine("- EDIT AN ENTRY IN THE PHONEBOOK -")
        Console.WriteLine("Enter the name of the entry you want to edit:")
        Dim editName As String = Console.ReadLine()
        Dim found = False

        For i As Integer = 0 To phoneBook.Count - 1
            Dim entry As String() = phoneBook(i)
            If entry(0).Equals(editName, StringComparison.OrdinalIgnoreCase) Then
                found = True ' Set found to true if the entry is found

                ' Prompt for new name and validate it
                Dim newName As String = ""
                Do
                    Console.WriteLine("Enter the new name :")
                    newName = Console.ReadLine()
                    If String.IsNullOrEmpty(newName) Then
                        Console.WriteLine("Name cannot be empty.")
                    End If
                Loop While String.IsNullOrEmpty(newName)

                ' Prompt for new number and validate it
                Dim newNumber As String = ""
                Dim isValidNumber As Boolean = False
                Do
                    Console.WriteLine("Enter the new phone number in the format (XXX-XXX-XXXX) (or press ENTER to keep the current number):")
                    newNumber = Console.ReadLine()
                    If String.IsNullOrEmpty(newNumber) Then
                        Console.WriteLine("Phone number cannot be empty")
                    ElseIf System.Text.RegularExpressions.Regex.IsMatch(newNumber, "^\d{3}-\d{3}-\d{4}$") Then
                        isValidNumber = True ' Set isValidNumber to true if the format is correct
                    Else
                        Console.WriteLine("Invalid phone number format.")
                    End If
                Loop Until isValidNumber

                ' Update the entry in the phonebook
                phoneBook(i) = New String() {newName, newNumber}
                Console.WriteLine()
                Console.WriteLine($"Entry '{editName}' has been updated to new name '{newName}' with phone number '{newNumber}'.")

                'Waiting 2 seconds and then clear the console
                System.Threading.Thread.Sleep(2000)
                Console.Clear()
                Exit For ' Exit the loop as we've finished editing the entry
            End If
        Next

        ' If the entry was not found, inform the user
        If Not found Then
            Console.WriteLine("Entry not found.")
        End If
    End Function

    ' Delete user
    Function deleteUser(ByRef phoneBook As ArrayList)
        Console.WriteLine()
        Console.WriteLine("- DELETING A ENTRY IN THE PHONEBOOK -")
        Console.WriteLine("Enter the name of the entry you want to delete:")
        Dim deleteName As String = Console.ReadLine()
        Dim found = False

        For i As Integer = 0 To phoneBook.Count - 1
            Dim entry As String() = CType(phoneBook(i), String())
            If entry(0).Equals(deleteName, StringComparison.OrdinalIgnoreCase) Then
                phoneBook.RemoveAt(i)
                found = True
                Console.WriteLine()
                Console.WriteLine(deleteName & " was removed from the phone book.")

                'Waiting 2 seconds and then clear the console
                System.Threading.Thread.Sleep(2000)
                Console.Clear()
                Exit For
            End If
        Next

        If Not found Then
            Console.WriteLine("Entry not found.")
        End If
    End Function

    ' Display
    Function displayPhoneBook(ByRef phoneBook As ArrayList)
        Console.WriteLine()
        Console.WriteLine("- DISPLAY THE PHONE BOOK -")
        For Each item As String() In phoneBook
            Console.WriteLine(item(0) & ": " & item(1))
        Next
    End Function


    ' SUB
    Sub displayMenu()
        Console.WriteLine()
        Console.WriteLine("****************************************************")
        Console.WriteLine("***************** Phone Book ***********************")
        Console.WriteLine("****************************************************")
    End Sub

    Sub displayOptions()
        Console.WriteLine("Select an option:")
        Console.WriteLine("1. Add")
        Console.WriteLine("2. Edit")
        Console.WriteLine("3. Delete")
        Console.WriteLine("4. Display")
        Console.WriteLine("5. Exit")
    End Sub
    Sub exitPhoneBook()
        Console.WriteLine()
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine("                             Thanks for using PHONE BOOK, a Major Software")
        Console.WriteLine("                             *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*")
        Console.WriteLine(vbNewLine)
        Threading.Thread.Sleep(2000)
        Console.Clear()
        MainMenuSub.mainMenuMenu()
        ' Exit the subroutine easyCalculator
        Return
    End Sub

End Module
