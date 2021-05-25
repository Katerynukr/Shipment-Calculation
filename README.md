# ShipmentClculation 
📚 Hi!This is a console application. 📚 

# Description 
The program reads shipment data from input.txt file and creates a list of shipments. The data in the file can be with valid and invalid shipments. Additionally, valid shipments should apply different pricing for the shipments depending on the parcel size (S, M, L) and on courier delivery services ('Mondial Relay' - MR in short or 'La Poste' - LP). The default price is stored in a static class PriceData, however, all the shipments should be checked for a possibility to apply discount. For example, L (Large) parcels that are delived by a LP courier can be be free, but only once a calendar, month as well as all S shipments should always match the lowest S package price among the providers. The maximum sum of discounts per month cannot axceed 10€. After creating the shipments, the data about the shipment including its price and discount is stored in the output.txt file. Finally, solutions outputs data to the console.
The application does not use dependency injection, since the main requirement is to omit libraries.

# Goal
The goal of this project is to practice: 
- factory design pattern
- testing (unit tests, fluent assertion)
- SOLID principles
- service-oriented architecture


