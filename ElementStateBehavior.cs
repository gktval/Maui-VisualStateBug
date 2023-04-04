using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStateBug.Behaviors;
public class ElementStateBehavior : Behavior<Button> {
    public static readonly BindableProperty TargetProperty =
        BindableProperty.CreateAttached(nameof(Target), typeof(Button), typeof(ElementStateBehavior), null);



    public static readonly BindableProperty StateProperty =
        BindableProperty.CreateAttached(nameof(State), typeof(string), typeof(ElementStateBehavior),
                                    null, BindingMode.TwoWay, propertyChanged: StateChanged);


    public Button Target {
        get { return (Button)base.GetValue(TargetProperty); }
        private set { base.SetValue(TargetProperty, value); }
    }

    public string State {
        get { return (string)base.GetValue(StateProperty); }
        private set { base.SetValue(StateProperty, value); }
    }

    private static void StateChanged(BindableObject bindable, object oldValue, object newValue) {
        var state = (ElementStateBehavior)bindable;
        if (newValue != null)
            VisualStateManager.GoToState(state.Target, (string)newValue);
    }

}