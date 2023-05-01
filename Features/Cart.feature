Feature: Cart
	Adding, removing and managing Cart

@cart
Scenario: Add Items to cart and remove the lowest price items from cart
	Given Go to Home Page
	And I add items to my cart
	| ItemName                 |
	| T-SHIRT-HAPPY-NINJA      |
	| T-SHIRT-NINJA-SILHOUETTE |
	| POSTER-PREMIUM-QUALITY   |
	| T-SHIRT-PREMIUM-QUALITY  |
	When I view my cart
	Then I verify total number of items listed in my cart '4'
	When I search for lowest price item
	And I am able to remove the lowest price item from my cart
	Then I verify total number of items listed in my cart '3'