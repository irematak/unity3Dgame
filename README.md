# unity3Dgame

https://simmer.io/@irematak/changingballs

## Oynanış
Oyununun genel mantığı cisimin içinden geçtiği topun rengine göre renk ve boyut değiştirmesidir.    
Başlangıçta oyunucunun 3 tane canı bulunmaktadır.    
Eğer kendisiyle aynı renkte bir topun içinden geçerse boyutu artmaktadır.     
Farklı renkte bir topun içinden geçerse boyutu küçülmektedir, rengi de o topun rengi olmaktadır ve ayrıca canı bir azalmaktadır.    
Oyuncunun canı sadece farklı bir topun içinden geçince azalmaktadır. Sahnede engel olarak bloklar da bulunmaktadır.   
Tüm canların bitmesiyle oyun sonlanmaktadır.    
Arrow tuşlarıyla cisim hareket etmektedir.    

PlayerMovement isimli scriptte Start fonksiyonu içinde cisim belli bir hızla başlatıldı. Update fonksiyonundaysa oyundaki girdiler Input.GetAxis() ile alındı. Bu şekilde arrow tuşlarıyla cisim hareket ettirilebilmektedir. Cismin platformdan dışarı çıkması durumu da incelendi. Platformun boyutuna bakılarak transform.position.x değerlerine göre sağdan ya da soldan çıkması durumunda cismin konumu tam  olarak ortalandı. Bu scriptte yer alan OnCollisionEnter fonksiyonunda cismin bloğa çarptıktan sonra nasıl hareket etmesi gerektiği kodlandı. İlk olarak collision olan cismin tag'i kontrol edildi eğer tag'i blok ise çarpışma sonrasında cismin konumu önceki konumundan 3.0f geride olacak şekilde ayarlandı ve hızı da 0.5f kat arttırıldı. Scriptte ayrıca jump isimli bir fonksiyon bulunmaktadır fakat henüz kullanılmamaktadır.    

player_sc scriptinde OnTriggerEnter fonksiyonunda OnTriggerEnter fonksiyonunda eğer triggerlanan cismin tag'i untagged değilse ObstacleControl fonksiyonuna gönderildi ve cismin tag'i ball ise cismin rengi triggerlanan cisiminki ile değiştirildi. Triggerlandığı cismin tag'i ground1 ya da ground2 ise yol 1 defa daha ötelenmektedir.    
ObstacleControl fonksiyonunda bool isSameColor değişkeniyle  çarpışılan cisim ile oyuncunun rengi karşılaştırılmaktadır. Eğer çarpışılan cisim blok değilse ve aynı renkteyse konsola "Same Color" yazdırılmaktadır ve cismin boyutu Vector3.one/4 kadar büyümektedir ve 10 puan artmaktadır. Triggerlanan cisim bu olaydan sonra ekrandan kaybolmaktadır. Eğer triggerlanan cisim bloksa ya da tag'i ball ve cisimle farklı renkteyse canı 1 azalmaktadır, 10 puan azalmaktadır, boyutu da Vector3.one/4 kadar azalmaktadır. Tag'i ball ise triggerlanma sonucu yok olmaktadır. Eğer canı biterse ya da cismin boyutu .1f altına düşerse oyun biter ve GameOver() fonksiyonu çağrılır.   
GameOver() fonksiyonunda asenkron olarak GameOver Sahnesine geçilmektedir. ObstacleControl() fonksiyonunda toplanan puan 20 ise ve 1. sahnede bulunuyorsa  GoNextLevel() fonksiyonu çağırılmaktadır. GoNextLevel() fonksiyonuysa asenkron olarak ikinci sahneye geçmeyi sağlıyor.    

İlk Sahne:   


<img width="521" alt="5" src="https://user-images.githubusercontent.com/75726319/213156391-755321b5-de92-4371-a56c-119bee6f7d0c.PNG">


Yeni sahneye geçmiş hali:   

<img width="519" alt="4" src="https://user-images.githubusercontent.com/75726319/213156179-7274ff52-c3dd-4bfc-9649-980441aa8fda.PNG">    

İki sahnede de Ara Menü sahnesine geçmek için buton bulunmaktadır.    

AnaMenu scriptinde resrtart() fonksiyonuyla asenkron olarak ilk sahneye geçilmektedir. Oyundaki Ana Menü sahnesinde ayrıca devam et butonu bulunmaktadır fakat kayıt alma işlemi projeye henüz eklenmediği için çalışmamaktadır.      

<img width="431" alt="2" src="https://user-images.githubusercontent.com/75726319/213155216-8aacd441-faed-4fc7-92ad-cf0b64a8894b.PNG">

ToAnaMenu scriptinde  Ana Menü sahnesine asenkron olarak geçiş sağlanmaktadır.   

ToAraMenu scriptinde ise Ara Menü sahnesine asenkron olarak geçiş sağlanmaktadır.   
Ara Menüde sadece Ana Menüye geçiş sağlayan bir buton bulunmaktadır.     

<img width="523" alt="1" src="https://user-images.githubusercontent.com/75726319/213154651-e1a2b066-ea08-48be-a4f9-72c561709363.PNG">

manager_sc scripti random konum ve sürede random olarak ürtilen nesnelerin kontrolünün sağlandığı kısımdır.            
gain_point_sc scriptinde  yol kontrolü sağlanmaktadır.   

PlayerCollisionControl scriptinde cisimlerin çarpışma durumlarına göre hangi sesin oynatılacağı belirtilmiştir. Eğer blok ile bir çapışma olursa bangClip   çalışmaktadır. Başka bir topla çarpışırsa eğer gainclip çalışmaktadır.   

bang_anim scriptinde çarpışma sonrası hangi animasyonların çalışacağı kodlanmıştır.   

Canlar bittikten sonra ya da topun boyutu belli bi seviyenin altına düşerse GameOver sahnesi gelmektedir. Bu sahnede sadece Ana Menu sahnesine asenkron geçişi sağlayan bir buton bulunmaktadır.     

<img width="524" alt="3" src="https://user-images.githubusercontent.com/75726319/213155843-bf43248d-0e13-4c5d-9f4c-50cee3ce90cf.PNG">

