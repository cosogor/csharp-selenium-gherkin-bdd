Feature: SearchResultPanel
    Input the search string to the Google Search Box
    Start search 
    Check Search Result Panel 

@SearchResultPanel
Scenario: Check Search Result Panel after successful search
	Given I have navigated to the google search page
	 When input the search string to the Search Box
     When click Search Button
     Then Search Result Panel available
     Then close the browser instance