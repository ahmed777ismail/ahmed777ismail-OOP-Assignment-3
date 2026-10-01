# Generics - answers

## Step 2

Both specific stores kept a list and repeated Add, GetById, GetAll, and Remove. Only the item type and domain properties differed: students have `Name`; courses have `Title` and `Price`.

## Step 3

Compiler error: `CS1061: 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found.` An unconstrained `T` can be any type, so the compiler cannot guarantee that it has an `Id` property.

## Step 7

`new Store<string>()` must not compile because `Store<T>` requires `T : IHasId`, and `string` does not implement `IHasId`. The constraint makes the store's ID operations type-safe at compile time.

The common name for the class built in Steps 4 and 5 is a **generic repository** (or repository). It centralizes collection-like persistence operations for entities that share an identity contract.
