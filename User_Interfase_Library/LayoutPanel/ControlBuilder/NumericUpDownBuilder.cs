using System.Windows.Forms;

namespace UserInterface.LayoutPanel.ControlBuilder;

public class NumericUpDownBuilder
{
    private readonly NumericUpDown _numeric = new();

    public NumericUpDownBuilder Value(decimal value)
    {
        _numeric.Value = value;
        return this;
    }

    public NumericUpDownBuilder Range(decimal min, decimal max)
    {
        _numeric.Minimum = min;
        _numeric.Maximum = max;
        return this;
    }

    public NumericUpDownBuilder DecimalPlaces(int places)
    {
        _numeric.DecimalPlaces = places;
        return this;
    }

    public NumericUpDownBuilder Binding(string propertyName, object dataSource, string dataMember)
    {
        _numeric.DataBindings.Add(propertyName, dataSource, dataMember);
        return this;
    }

    public NumericUpDown Build() => _numeric;
}