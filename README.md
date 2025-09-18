# Colored Portraits
Adds an appearance behaviour that makes a card's portrait colored.

# How to use - C# users
To add the appearance behaviour to your card you made using code, do `yourcard.AddAppearances(GuidManager.GetEnumValue<CardAppearanceBehaviour.Appearance>("spapi.inscryption.coloredportraits", "ColoredPortrait"));`

# How to use - JSONLoader users
To add the appearance behaviour to your card you made using jsonloader, do
```
"appearanceBehaviour": [
	"spapi.inscryption.coloredportraits.ColoredPortrait"
]
```