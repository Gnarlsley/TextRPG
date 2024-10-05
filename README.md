Organized Project Files


#######################

Directories:

DialogueType - 

    Class: Dialogue
        Enums: Mood
            Positive, Neutral, Negative
        Attributes:
            Response
    Interface: IStoryElement
        Attributes:
            DisplayText
        Methods: 
            Display
EntityType -

    Abstract Class: Entity
        Attributes:
            Name, Health, Damage, Luck, Speed, Dexterity, Defense
        Methods:
            -No-Argument Constructor with default values
            -Display Stats message
    Class: Player extends Entity
        Attributes:
            Inherits Entity attributes and adds Consumable Charges
        Methods:
            -Display Charges
    Class: NPC extends Entity and IStoryElement
        Attributes:
            Inherits attributes from Entity and IStoryElement, adds Dialogues which is a list of Dialogue objects
        Methods:
            Inherits Display method from IStoryElement
WorldInteraction -

    Class: InteractWorld
        Methods:
            InteractLocation:
                Checks if NPC is at location, then prompts user to respond to NPC via "talk" command
