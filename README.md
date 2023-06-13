# SolitareTDD
Just some TDD practice for the group, and this time solitaire was not mis-typed! :-)  
Design decisions are written in MS Word saved as .htm  and is located here: JChrisCompton » Solitaire_TDD » SolitaireTDD » TDD Design Decisions_files

---

# Markdown practice 
This is practice with markdown.
## This IS NOT related to the TDD project!


This is all Markdown practice:


## Flowcharts

```mermaid
graph LR
	A --> B
	A --> C
	B --> D
	C --> D
```

```mermaid
graph TD
	A[Start] -.-> B(Process 1)
	A --> C[[Process 2]]
	B ==o D(Stop)
	C --> D
```

## Class Diagrams

```mermaid
classDiagram
	class IValidatableObject {
		<<interface>>
		Validate() IEnumerable~ValidationResult~
	}
	class Address {
		+Id : GUID
		+Address1 : string
		+Address2 : string
		+City : string
		+State : string
		+ZipCode : string
	}
	Address ..|> IValidatableObject : implements
	class Person {
		+Id : GUID
		+FirstName : string
		+LastName : string
		+FullName : string
		+EmailAddress : string
		+Address Add
		+Validate() IEnumerable~Validation~Result~
	}
	Person ..|> IValidatableObject : implements
	Person "1" --> "0..1" Address
```

		-privateProperty : string
		#ProtectedProperty : string
		%InternalProperty : string
Internal should be a tilda "~", but we're using a percent "%" because the markdown editor is a little broken.

