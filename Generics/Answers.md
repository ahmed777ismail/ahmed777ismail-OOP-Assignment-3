# Generics - answers

## Step 2

Both stores keep a list and implement the same Add, GetById, GetAll, and Remove algorithm. Only the stored type and its descriptive properties differ: students have `Name`; courses have `Title` and `Price`.

## Step 3

Compiler error: `CS1061: 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found.` The compiler rejects `item.Id` because an unconstrained `T` can be any type, so it cannot guarantee that every value has an `Id` property.
