Bonjour à toi developpeur voici un Kata Web api Complet
Emmanuel Conrardy
08/08/2017

On souhaite exposer une API pour réserver des salles de réunion.
Cette API permet de
-          Lister des salles -> Get IEnumarable -> RoomController
-          Créer des réservations -> Post -> BookingController
-          Supprimer des réservations -> Delete -> BookingController
-          En cas de conflit (de réservation), l’api doit proposer tous les créneaux libres de la journée demandée. -> Get -> BookingController
 
 +RoomServices
 +BookingServices

 +RoomRepository (singleton)
 +BookingRepository

Pour simplifier au maximum l’exercice
 
1) il y a 10 salles ( « room0 » … « room9 » )
-> List Room
	-name
	-number
2) une réservation est
-          Au nom d’une seule personne ( paramètre « user » ) -> User (nom, prenom)
-          Concerne toujours une seule salle ( paramètre « room ») -> Room
-          Sur un créneau début / fin - la journée est découpée en créneaux d’1 heure (24 créneaux donc) BookingRange -> Day -> Year, Month, Day, List hour 
-          Jamais sur plusieurs jours -> TDD BookingServices - IsNoConflict()
3) le back-end n’a pas d’importance, peut-être in-memory par exemple. Mais fonctionnellement, vous devez gérer les conflits (donc maintenir un état) – cf ci-dessus
 
 
Le but de ce kata est de montrer
-          Votre approche de modélisation « restful » de cette API (url paths, status codes …)
-          Votre maitrise d’asp.net webapi (owin, etc.) – vous pouvez hoster dans IIS ou en self-hosted, peu importe
-          Bonus : incorporer https://www.nuget.org/packages/Swashbuckle pour exposer le swagger de cette API et interagir avec dynamiquement (« try out »).
incorporer des valeurs exemple (payload de retour de chaque operation) -> http://localhost:<your-port>/swagger/

Le but de ce kata n’est pas de démontrer une API scalable/distribuée/load-balancée, avec un back-end persisté.
Les tests sont un plus mais pas exigés pour cet exercice.

