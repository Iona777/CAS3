@mytagEden
Feature: TransferInHappy1
	In order to enter a Pru App ISA Application 
	As an authorised user
	I want to complete all required data and successfully submit an application with a Transfer In.


Scenario: Enter a Pru App ISA application to completion with a Transfer In payment only. Enter any valid data for mandatory fields.

	Given That the user is on the the Login page
	When  They enter valid login credentials and click on the Login button 
	Then  The Dashboard screen should be displayed

	When  The user enters any valid data for the mandatory fields prior to the Investment Funds screen using file 'JsonDataSourceTransferHappy1.json'
	Then  The Investment Funds screen should be displayed

	When  The user enters valid data for a Transfer Investment only in the Investment Funds screen and clicks on the Continue application button
	Then  The Transfer In screen should be displayed

	When  The user enters valid data in the Transfer In screen using file 'JsonDataSourceTransferHappy1.json' and clicks on the Continue application button
	Then  The Transfer In Set-up Adviser Charge screen should be displayed 

	When  The user enters valid data in the Transfer In Set-up Adviser Charge screen using file 'JsonDataSourceTransferHappy1.json' and clicks on the Continue application button
	Then  The Ongoing Charges screen should be displayed

	When  The user selects No Ongoing Charges and No Regular Withdrawal after the Transfer In Set-up Adviser Charge screen
	Then  The CVI Investor screen should be displayed
	And   The mandatory fields are populated

	When  The user enters any valid data between the CVI Investor screen and Investor declaration choice screen using file 'JsonDataSourceTransferHappy1.json' and clicks on the Continue application button
	Then  The Investor Declaration Choice screen should be displayed
	
	When  The user selects a valid option in the Investor Declaration Choice screen and clicks on the Continue application button
	Then The Application Summary screen should be displayed

	When The user clicks on the Submit application button in the Application Summary screen
	Then The Next Steps screen should be displayed
	
	When The user clicks on the Return to dashboard button on the Next Steps screen
	Then The Dashboard screen should be displayed

	When The user clicks on the Show my applications button in the Dashboard screen
	Then Applications displayed and the latest one has a Status of Completed
