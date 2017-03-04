# Demo iOS FAB
FAB as demo'd in fourth module of the [Moving Beyond the Basics with Xamarin.Forms](https://www.pluralsight.com/courses/xamarin-forms-moving-beyond-basics) course.

## Implementation
This is a very simple example, and only meant as a jumping off point. The circle and the "plus sign" on the button were implemented with CoreGraphics. 

The drawing of the button occurs in the `Draw` function, which is an overridden function provided by the `UIView` class - which this button derives from.

The `TouchesBegan` and `TouchesEnded` functions are overridden to provide a means for the button to report when the user is interacting with it. During the `TouchesBegan` a "tinting" layer is inserted into the view hierarchy - so provide something of a shadow - so the user can see it's being tapped.

Finally, there is a very simple `EventHandler<EventArgs> ButtonPressed` which gets invoked during the `TouchesEnded` function. This is how the button notifies any subscribers that it has been interacted with. (The `EventArgs` is probably unnecessary in this case - since we're only saying it's been touched.)

Hope this helps - and don't forget to rate the course 5 stars! :)