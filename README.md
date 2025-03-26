A LOAN SYSTEM THAT WILL ASK FOR USER TO INPUT IT'S BORROWER NAME AND BORROWED AMOUNT ALSO THE INTEEST RATE AND WILL STORE IN MYSQL DATABASE 
======================================
Operations
--------------------------------------
1   : Add new record
2   : Update record
3   : Mark loan status
4   : Display Records
5   : Delete Record
any : To exit
======================================
Do you want to do another operation? : 
1
Enter the borrower name
popo
Enter the amount borrowed
20000
Enter the interest
4

Record added successfully!
popo borrows 20000 with the interest rate of 4.
Which you will gain 800 as interested amount.

======================================
Operations
--------------------------------------
1   : Add new record
2   : Update record
3   : Mark loan status
4   : Display Records
5   : Delete Record
any : To exit
======================================
Do you want to do another operation? : 
2
Enter the ID of the record to update:
7
Enter the new borrower name
KEKE
Enter the new amount borrowed
900
Enter the new interest
7

Record updated successfully!
Updated to: KEKE borrows 900 with interest rate 7%

======================================
Operations
--------------------------------------
1   : Add new record
2   : Update record
3   : Mark loan status
4   : Display Records
5   : Delete Record
any : To exit
======================================
Do you want to do another operation? : 
3
Enter the ID of the record to mark as paid:
7

Loan status for KEKE updated to 'paid'!

======================================
Operations
--------------------------------------
1   : Add new record
2   : Update record
3   : Mark loan status
4   : Display Records
5   : Delete Record
any : To exit
======================================
Do you want to do another operation? : 
4

All Loan Records:
--------------------------------------------------
Borrower ID: 7
Borrower Name: popo
Amount Borrowed: 900
Interest Rate: 7%
Interest Amount: 63
Status: paid
--------------------------------------------------

======================================
Operations
--------------------------------------
1   : Add new record
2   : Update record
3   : Mark loan status
4   : Display Records
5   : Delete Record
any : To exit
======================================
Do you want to do another operation? : 
5
Enter the ID of the record to delete:
7

Record deleted successfully!
