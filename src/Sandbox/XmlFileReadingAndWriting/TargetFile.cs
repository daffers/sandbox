﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;
namespace XmlFileReadingAndWriting
{
}

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class SuppoertedLocals {
    
    private SuppoertedLocalsLocale[] localeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Locale", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
    public SuppoertedLocalsLocale[] Locale {
        get {
            return this.localeField;
        }
        set {
            this.localeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class SuppoertedLocalsLocale {
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class LanguageLocaleMappings {
    
    private object[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("LanguageLocalMapping", typeof(LanguageLocaleMappingsLanguageLocalMapping), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlElementAttribute("LanguageLocaleMapping", typeof(LanguageLocaleMappingsLanguageLocaleMapping), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlElementAttribute("SuppoertedLocals", typeof(SuppoertedLocals))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class LanguageLocaleMappingsLanguageLocalMapping {
    
    private string defaultLocaleField;
    
    private SuppoertedLocalsLocale[][] suppoertedLocalsField;
    
    private string iso6391LanguageCodeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string DefaultLocale {
        get {
            return this.defaultLocaleField;
        }
        set {
            this.defaultLocaleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Locale", typeof(SuppoertedLocalsLocale), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public SuppoertedLocalsLocale[][] SuppoertedLocals {
        get {
            return this.suppoertedLocalsField;
        }
        set {
            this.suppoertedLocalsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("iso639-1LanguageCode")]
    public string iso6391LanguageCode {
        get {
            return this.iso6391LanguageCodeField;
        }
        set {
            this.iso6391LanguageCodeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class LanguageLocaleMappingsLanguageLocaleMapping {
    
    private string defaultLocaleField;
    
    private SuppoertedLocalsLocale[][] suppoertedLocalsField;
    
    private string iso6391LanguageCodeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string DefaultLocale {
        get {
            return this.defaultLocaleField;
        }
        set {
            this.defaultLocaleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Locale", typeof(SuppoertedLocalsLocale), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public SuppoertedLocalsLocale[][] SuppoertedLocals {
        get {
            return this.suppoertedLocalsField;
        }
        set {
            this.suppoertedLocalsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute("iso639-1LanguageCode")]
    public string iso6391LanguageCode {
        get {
            return this.iso6391LanguageCodeField;
        }
        set {
            this.iso6391LanguageCodeField = value;
        }
    }
}
