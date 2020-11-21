# MobileContacts

Requirements:

· Develop a reusable library in C# to manage phone books for users. No user interface is required, only an API to create, delete and edit phone book entries.

· Each entry would contain: name (first and last), type (Work, Cellphone or Home) and number.

· Multiple entries under the same name are allowed.

· The persistence format of the phone book library should be a file, which is not text-based (XML, JSON etc. are not allowed) and is not an embedded DB either (i.e. SQLite, Access, Excel, etc. are not allowed).

· In addition to creating/editing/deleting, the library also needs to support iterating over the list in alphabetical order or by the first or last name of each entry.

· Create unit tests in your project (preferably with NUnit).

· Use Thread-safety of the library as a feature and XML documentation of the API
