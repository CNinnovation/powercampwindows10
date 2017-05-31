# Lab 3 - Binding

Binding, IValueConverter, DataTemplateSelector, ObservableCollection

You can use models different from Book - any type you like - to create list and detail information

1. Create a Book model type with some properties
2. Create a BindableBase abstract class with an implementation of the INotifiyPropertyChanged interface
3. Create a BooksService to return a list of Book objects
4. Use the BooksService with the code-behind of a page, and set the DataContext
5. In the page create a ListBox (or other ItemsControl objects) to display a list of books
6. Display detail information by using the SelectedIteme property of the ListBox
7. Create DataTemplates to define the look of items in the ListBox
8. Create and use a DataTemplateSelector for different item looks
9. Use an ObservableCollection to change the list dynamically

10. Change the binding to use compiled binding
