Bonjour � toi developpeur voici un Kata Web api Complet
Emmanuel Conrardy
08/08/2017

On souhaite exposer une API pour r�server des salles de r�union.
Cette API permet de
-          Lister des salles -> Get IEnumarable -> RoomController
-          Cr�er des r�servations -> Post -> BookingController
-          Supprimer des r�servations -> Delete -> BookingController
-          En cas de conflit (de r�servation), l�api doit proposer tous les cr�neaux libres de la journ�e demand�e. -> Get -> BookingController
 
 +RoomServices
 +BookingServices

 +RoomRepository (singleton)
 +BookingRepository

Pour simplifier au maximum l�exercice
 
1) il y a 10 salles ( � room0 � � � room9 � )
-> List Room
	-name
	-number
2) une r�servation est
-          Au nom d�une seule personne ( param�tre � user � ) -> User (nom, prenom)
-          Concerne toujours une seule salle ( param�tre � room �) -> Room
-          Sur un cr�neau d�but / fin - la journ�e est d�coup�e en cr�neaux d�1 heure (24 cr�neaux donc) BookingRange -> Day -> Year, Month, Day, List hour 
-          Jamais sur plusieurs jours -> TDD BookingServices - IsNoConflict()
3) le back-end n�a pas d�importance, peut-�tre in-memory par exemple. Mais fonctionnellement, vous devez g�rer les conflits (donc maintenir un �tat) � cf ci-dessus
 
 
Le but de ce kata est de montrer
-          Votre approche de mod�lisation � restful � de cette API (url paths, status codes �)
-          Votre maitrise d�asp.net webapi (owin, etc.) � vous pouvez hoster dans IIS ou en self-hosted, peu importe
-          Bonus : incorporer https://www.nuget.org/packages/Swashbuckle pour exposer le swagger de cette API et interagir avec dynamiquement (� try out �).
incorporer des valeurs exemple (payload de retour de chaque operation) -> http://localhost:<your-port>/swagger/

Le but de ce kata n�est pas de d�montrer une API scalable/distribu�e/load-balanc�e, avec un back-end persist�.
Les tests sont un plus mais pas exig�s pour cet exercice.

