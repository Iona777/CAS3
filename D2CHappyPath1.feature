Feature: D2CHappyPath1
	In order to enter a D2C Pru App ISA Application
	As an online investor
	I want to complete all required data and successfully submit an application with single, regular and transfer in investment payments.


@mytagEden
Scenario: Complete D2C application and make online card payment successfully
	#Given That I am using file 'D2CAllInvestments1' for the input data

	Given That the investor is on the the D2C Welcome page
	When  The investor clicks on Continue on the D2C Welcome page
	Then  The D2C Details page should be displayed

	#When The investor enters valid hardcoded data on the D2C Details screen and clicks on the Continue button
	When The user enters valid data in the D2C Details screen using file 'D2CAllInvestments1.json' and clicks on the Continue button
	Then The D2C Your Details page should be displayed

	#When The investor enters valid hardcoded data in the D2C Your Details screen and clicks on the Continue button
	When The user enters valid data in the D2C Your Details screen using the file 'D2CAllInvestments1.json' and clicks on the Continue button
	Then The D2C Investment Details page should be displayed

	#Not necessary to enter data via a file since you don't really care what fund or values are selected, just the type of investment(s)
	#and this should really be specified here in the feature
	When The investor enters valid hardcoded data for Single, Regular and Transfer In investments on the D2C Investment Details screen and clicks on the Continue button

	Then  The D2C Transfer In page should be displayed

	#When The investor enters valid hardcoded data in the D2C Transfer In screen and clicks on the Continue button
	When The investor enters valid data in the D2C Transfer In screen using the file 'D2CAllInvestments1.json' and clicks on the Continue button
	Then The D2C Direct Debit page should be displayed

	#When The investor enters valid hardcoded data in the D2C Direct Debit screen and clicks on the Continue button
	When The investor enters valid data in the D2C Direct Debit screen using the file 'D2CAllInvestments1.json' and clicks on the Continue button
	Then The D2C Summary page should be displayed

	When The investor clicks on the Continue button in the D2C Summary page 
	Then The D2C Investor Declaration page should be displayed

	#When The investor selects all the tick boxes in the D2C Investor Declaraton screen and clicks on the Continue button
	When The investor enters valid data in the D2C Investor Declaration screen using the file 'D2CAllInvestments1.json' and clicks on the Continue button
	Then The D2C Next Steps page should be displayed

	When The investor clicks on the Continue button in the D2C Next Steps page
	Then The Hosted Payment Page should be displayed

	#The card details are not held in the Json file. Use hard coded valid and invalid details instead
	When The investor enters valid hardcoded data in the D2C Hosted Payment screen and clicks on the Pay Now button
	Then The D2C Payment successful page should be displayed


