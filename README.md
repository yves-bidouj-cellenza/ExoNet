### ExoNet

## Enoncé

Faire un website C# .net en webapi avec 2 webservices qui acceptent des paramètres et retournent du json :
-    /api/authenticate ( pas besoin d’authentification ). Paramètres du ws « email » et « password ». Retourne « true » ou « false »
-    /api/confidentials ( authentifié ). Paramètre « email ». Retourne le  « true » ou « false ».
 
Pour le service /api/confidentials implémenter le même mode d’authentification que AWS dont la doc est ici :  http://docs.aws.amazon.com/AmazonS3/latest/dev/RESTAuthentication.html
 
 
    NOTES :
    1/ Pas besoin de faire un projet avec des accès en base de données, des données mockées suffisent
    2/ Il n’y a pas de solution idéale
    3/ L’énoncé est volontairement vague



## Solution proposée :

1. Site Web C#

    <a href=".\ExoNet.WebApp">WebApp<a/>
1. Sevrvice Web (api/authenticate) C#

    <a href=".\ExoNet.WebApp.WebService">WebService<a/>
    
1. Sevrvice Web (api/confidentials)  C#

    <a href=".\ExoNet.WebApp.SecuredWebService">SecuredWebService<a/>