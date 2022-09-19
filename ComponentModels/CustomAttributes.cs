namespace Perius.ComponentModels.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SkipAditionalPropertyAttribute : Attribute
    {
        // Ignora las propiedades adicionales de un modelo.
    }
}
