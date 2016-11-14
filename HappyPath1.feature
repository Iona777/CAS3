Feature: HappyPath1
	In order to enter a D2C Pru App ISA Application
	As an authorised user
	I want to complete all required data and successfully submit an application with a single investement payment.


@mytagEden
Scenario: Enter valid data for all mandatory fields on each field until Summary page is displayed. Click on Submit and Dashboard screen displayed
	#Given That I am using file 'JsonDataSourceHappy1.json' for the input data

	Given That the user is on the the Login page
	When  They enter valid login credentials and click on the Login button 
	Then  The Dashboard screen should be displayed

	When  The user clicks on the Apply now button 
	Then  The New or Existing Investor screen should be displayed

	When  The user clicks on the Continue as new investor button 
	Then  The New investor details screen should be displayed

	When  The user enters valid data in the New Investor details screen using file 'JsonDataSourceHappy1.json' and clicks on the Continue application button
	Then  The Investor Nationality screen is displayed 

	When  The user enters valid data in the Investor Nationality screen using file 'JsonDataSourceHappy1.json' and clicks on the Continue application button
	Then  The Investment Funds screen should be displayed

	When  The user enters valid data  Single Investment in the Investment Funds screen and clicks on the Continue application button
	Then  The Single Investment Set-up Adviser Charge screen should be displayed

	When  The user enters valid data in the Single Charge screen using file 'JsonDataSourceHappy1.json' and clicks on the Continue application button
	Then  The Ongoing Charges screen should be displayed

	When  The user enters valid data in the Ongoing charges screen using file 'JsonDataSourceHappy1.json' and clicks on the Continue application button
	Then  The Regular Withdrawals screen should be displayed

	When  The user enters valid data in the Regular Withdrawals screen using file 'JsonDataSourceHappy1.json'and clicks on the Continue application button
	Then  The Single Investment Payment Details screen should be displayed

	When The user user enters valid data in the Single investment payment details screen using file 'JsonDataSourceHappy1.json'and clicks on the Continue application button
	Then The CVI Investor screen should be displayed
	And  The mandatory fields are populated

	When The user clicks on the Continue application button in the CVI Investor screen screen
	Then The CVI Investor page 2 screen should be displayed

	When The user enters valid data in the CVI Investor Page 2 screen and clicks on the Continue application button
	Then The Adviser Declaration screen should be displayed
	#And  The adviser details are prepopulated

	When The user enters valid data in the Adviser Declaration screen using file 'JsonDataSourceHappy1.json'and clicks on the Continue application button
	Then The Investor Declaration Choice screen should be displayed

	When  The user selects a valid option in the Investor Declaration Choice screen and clicks on the Continue application button
	Then The Application Summary screen should be displayed

	When The user clicks on the Submit application button in the Application Summary screen
	Then The Next Steps screen should be displayed
	
	When The user clicks on the Return to dashboard button on the Next Steps screen
	Then The Dashboard screen should be displayed

	When The user clicks on the Show my applications button in the Dashboard screen
	Then Applications displayed and the latest one has a Status of Submitted