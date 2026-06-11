# Codara Product Requirements Document ve Öğrenme Tasarımı

**Belge sürümü:** 1.0  
**Tarih:** 11 Haziran 2026  
**Ürün aşaması:** MVP öncesi ürün tanımı  
**İlk kurs:** Python Başlangıç  
**Hedef platformlar:** Android ve iOS, dikey mobil ekran  

## 1. Belgenin Amacı

Bu belge, Codara'nın ürün gereksinimlerini ve öğrenme yaklaşımını tanımlar. Ürün, tasarım, içerik, mühendislik, veri ve kalite ekipleri için ortak karar kaynağıdır.

Codara'nın temel amacı, programlamaya yeni başlayan kullanıcıların her gün 5-10 dakikalık odaklı çalışmalarla temel Python becerileri edinmesini ve öğrendiklerini kalıcı hale getirmesini sağlamaktır.

Codara, kullanıcı tarafından yazılan güvensiz kodu çalıştıran bir kod yürütme ortamı değildir. MVP'deki bütün egzersizler, önceden tanımlanmış ve deterministik değerlendirme kurallarıyla kontrol edilir.

## 2. Ürün Vizyonu ve İlkeler

### 2.1 Ürün vizyonu

Codara, programlama öğrenmeye başlamak isteyen kişiye her gün tamamlanabilir, anlaşılır ve ölçülebilir bir sonraki adımı sunan oyunlaştırılmış mobil öğrenme uygulamasıdır.

### 2.2 Ürün vaadi

Kullanıcı, günde 5-10 dakika ayırarak Python'ın temel kavramlarını anlayacak, kısa egzersizlerle uygulayacak, hatalarını tekrar ederek düzeltecek ve üç mini projeyle başlangıç seviyesinde anlamlı çıktılar oluşturacaktır.

### 2.3 Temel ürün ilkeleri

- **Kısa ama anlamlı:** Her oturum küçük bir öğrenme hedefini tamamlar.
- **Hatadan öğrenme:** Yanlış cevap, ceza değil öğrenme verisidir.
- **Aktif hatırlama:** Kullanıcı yalnızca okumaz; düzenli olarak cevap üretir.
- **Kademeli zorluk:** Yeni bilgi, önceki bilgi üzerine kontrollü biçimde eklenir.
- **Açık ilerleme:** Kullanıcı neden ilerlediğini ve neyi tekrar etmesi gerektiğini görür.
- **Etik oyunlaştırma:** Mekanikler öğrenmeyi destekler; korku, utandırma veya harcama baskısı oluşturmaz.
- **Çevrimdışı erişim:** İndirilen dersler ve temel ilerleme döngüsü internet olmadan çalışır.
- **Güvenli değerlendirme:** MVP'de kullanıcı kodu cihazda veya backend üzerinde çalıştırılmaz.

## 3. Hedef Kullanıcı Kitlesi

### 3.1 Birincil kullanıcılar

**Programlamaya tamamen yeni başlayanlar**

- Yaklaşık 13 yaş ve üzeri öğrenciler ve yetişkinler.
- Daha önce kod yazmamış veya çok sınırlı deneyimi olan kişiler.
- Uzun video kurslarına düzenli zaman ayıramayan kullanıcılar.
- Telefonda, kısa oturumlarla öğrenmeyi tercih edenler.
- Teknik İngilizce ve soyut programlama kavramları karşısında zorlanabilenler.

**Başlayıp bırakanlar**

- Daha önce Python kursuna başlamış fakat süreklilik sağlayamamış kişiler.
- Temel kavramları parçalı bilen ancak bilgi boşlukları bulunan kullanıcılar.
- Nereden devam edeceğini bilmediği için motivasyon kaybedenler.

### 3.2 İkincil kullanıcılar

- Okulda programlama dersi alan ve ek pratik isteyen öğrenciler.
- Kariyer değişikliği öncesinde programlamaya yatkınlığını değerlendirmek isteyen yetişkinler.
- Ebeveyn veya öğretmen yönlendirmesiyle temel algoritmik düşünme çalışmak isteyen genç kullanıcılar.

### 3.3 MVP'de hedeflenmeyen kullanıcılar

- İleri seviye Python geliştiricileri.
- Profesyonel IDE, hata ayıklayıcı veya serbest kod çalıştırma ortamı arayanlar.
- Veri bilimi, web geliştirme veya yapay zeka alanında uzmanlaşma içeriği bekleyenler.
- Kurumsal eğitim yönetimi ve sınıf yönetimi özelliklerine ihtiyaç duyan kurumlar.

## 4. Kullanıcıların Codara'yı Kullanma Nedenleri

- Programlamaya nereden başlayacağını bilmemek.
- Her gün kısa ve yönetilebilir bir öğrenme hedefi istemek.
- Uzun ders anlatımları yerine etkileşimli pratik tercih etmek.
- Yanlışlarının nedenini anlayıp hedefli tekrar yapmak.
- Günlük ilerlemeyi ve öğrenme sürekliliğini görünür hale getirmek.
- Boş zamanlarda telefondan çevrimdışı çalışabilmek.
- Tam bir kursa başlamadan önce Python'a ilgisini ve yatkınlığını ölçmek.
- Mini projelerle öğrendiği kavramların birlikte nasıl kullanıldığını görmek.

## 5. Codara'yı Rakiplerinden Ayıran Özellikler

- **Hata odaklı kişisel tekrar:** Yanlış cevaplar yalnızca kaydedilmez; hata türüne ve konu etiketine göre tekrar oturumlarına dönüştürülür.
- **Açıklanabilir değerlendirme:** Her yanlış cevap sonrasında doğru cevapla birlikte kavramsal neden ve ilgili mikro açıklama gösterilir.
- **Mobil için tasarlanmış deterministik kod egzersizleri:** Serbest kod çalıştırmadan, gerçek kod okuma ve oluşturma becerisini ölçen güvenli etkileşimler sunar.
- **5-10 dakikalık tamamlanabilir oturumlar:** Dersler küçük öğrenme hedefleri ve net bitiş noktaları etrafında tasarlanır.
- **Kod Rotası üzerinde ustalık görünümü:** İlerleme yalnızca tamamlanan ders sayısıyla değil, konu ustalığı ve tekrar ihtiyacıyla gösterilir.
- **Özgün teknoloji kimliği:** Nox, Byte, Kod Zinciri, İşlem Gücü, Sistem Yedeği ve Dev Arenası gibi Codara'ya özgü kavramlar kullanılır.
- **Çevrimdışı öncelikli öğrenme:** İndirilen içerik, cevap değerlendirme ve ilerleme kaydı bağlantı olmadan kullanılabilir.
- **Etik motivasyon:** Kullanıcıyı kayıp korkusu veya ödeme baskısıyla yönlendirmek yerine sürdürülebilir alışkanlığı destekler.

## 6. Temel Kullanıcı Yolculuğu

1. Kullanıcı uygulamayı açar ve Codara'nın kısa oturumlarla Python öğrettiğini görür.
2. Öğrenme amacı ve deneyim seviyesi hakkında kısa seçimler yapar.
3. Bildirim ve günlük hedef tercihini belirler.
4. İlk mikro dersi tamamlar.
5. Ders sonunda kazandığı Byte, kalan İşlem Gücü ve Kod Rotası ilerlemesini görür.
6. Ertesi gün günlük görev veya önerilen ders aracılığıyla devam eder.
7. Yanlış cevapları Hata Tekrar Alanı'nda yeniden çözer.
8. Ünite sonlarında mini değerlendirme veya mini proje tamamlar.
9. Derslerde yeterli ustalığa ulaştıkça yeni Kod Rotası düğümlerinin kilidini açar.
10. Kurs sonunda Python başlangıç yeterlilik özetini ve güçlendirmesi gereken konuları görür.

## 7. Günlük Öğrenme Döngüsü

Codara'nın temel günlük döngüsü:

**Ders seç → Kısa açıklama oku → İnteraktif soruları çöz → Hatalarını incele → Byte kazan → Kod Zinciri'ni koru → Yeni derslerin kilidini aç → Zayıf konuları tekrar et**

### Önerilen 5-10 dakikalık oturum

| Aşama | Hedef süre | Amaç |
|---|---:|---|
| Karşılama ve günlük hedef | 15-30 sn | Kullanıcıya net bir sonraki adımı göstermek |
| Ön bilgiyi hatırlama | 30-60 sn | Önceki öğrenmeyi geri çağırmak |
| Mikro açıklama ve örnek | 1-2 dk | Tek bir yeni kavramı öğretmek |
| 4-6 etkileşimli egzersiz | 3-5 dk | Bilgiyi uygulatmak ve ölçmek |
| Hata açıklaması ve düzeltme | 1-2 dk | Yanlış anlamayı gidermek |
| Sonuç ve sonraki öneri | 15-30 sn | İlerlemeyi görünür kılmak |

Kullanıcı günlük döngüyü tek bir dersle tamamlayabilir. Daha uzun çalışma teşvik edilebilir ancak zorunlu tutulmaz.

## 8. İlk Kullanıcı Deneyimi

### 8.1 Hedefler

- Kullanıcıya ilk 90 saniye içinde Codara'nın nasıl çalıştığını göstermek.
- Kayıt olmayı ilk öğrenme deneyiminin önüne koymamak.
- Kullanıcıya ilk oturumda gerçek bir başarı hissi vermek.
- Günlük hedef ve bildirim tercihlerini kullanıcı kontrolünde belirlemek.

### 8.2 Önerilen akış

1. **Açılış:** Codara adı, Nox'un kısa tanıtımı ve “Her gün 5-10 dakikada Python öğren” vaadi.
2. **Amaç seçimi:** Merak, okul desteği, kariyer başlangıcı veya beceri geliştirme.
3. **Deneyim seçimi:** İlk kez başlıyorum veya temelleri biraz biliyorum.
4. **İlk ders:** Değişken kavramını tanıtan 3-4 dakikalık rehberli ders.
5. **İlk sonuç:** Byte kazanımı ve Kod Rotası'nda ilk düğümün tamamlanması.
6. **Günlük hedef:** Haftada 3, 5 veya 7 gün seçimi. Varsayılan öneri haftada 5 gündür.
7. **Bildirim izni:** Önce bildirimlerin faydası açıklanır, ardından işletim sistemi izni istenir.
8. **Hesap seçeneği:** İlerlemeyi yedeklemek ve cihazlar arası eşitlemek için hesap oluşturma önerilir. Misafir devam seçeneği korunur.

### 8.3 İlk kullanıcı deneyimi kuralları

- Kullanıcıya başlangıçta uzun özellik turu gösterilmez.
- İlk ders tamamlanmadan premium teklif gösterilmez.
- İşlem Gücü ilk oturumu engellemez.
- İlk yanlış cevap, öğretici geri bildirimle karşılanır ve ilerlemeyi durdurmaz.
- Bildirim izni reddedilirse kullanıcı tekrar tekrar rahatsız edilmez.

## 9. Kod Rotası

Kod Rotası, kurs içindeki öğrenme ilerlemesini gösteren yönlendirilmiş bir beceri haritasıdır.

### 9.1 Yapı

- Her kurs, sıralı ünitelerden oluşur.
- Her ünite, ana yol üzerindeki ders düğümlerini ve belirli noktalardaki mini proje düğümlerini içerir.
- Dersler ön koşullara göre açılır.
- Kullanıcının sıradaki önerilen dersi belirgin gösterilir.
- Tamamlanan düğümler; tamamlanma, ustalık ve tekrar ihtiyacı durumlarını ayrı biçimde gösterebilir.

### 9.2 Düğüm durumları

- **Kilitli:** Ön koşul tamamlanmamıştır.
- **Hazır:** Kullanıcı dersi başlatabilir.
- **Başlandı:** Ders yarım kalmıştır ve çevrimdışı ilerleme kaydı bulunur.
- **Tamamlandı:** Dersin bitirme koşulu sağlanmıştır.
- **Güçlendirilmeli:** İlgili kavramlarda tekrar zamanı gelmiştir.
- **Ustalaşıldı:** Kullanıcı farklı zamanlarda yeterli doğruluk göstermiştir.

### 9.3 Kilit açma ilkesi

- Ana yol üzerindeki sıradaki ders, önceki zorunlu ders tamamlandığında açılır.
- Kullanıcıdan kusursuz sonuç beklenmez; öğrenme yolculuğu tek bir hatayla durmaz.
- Mini projeler, gerekli temel dersler tamamlanınca açılır.
- Hata tekrar alanı, ilk yanlış cevap kaydedildiğinde kullanılabilir hale gelir.

## 10. Kurs, Ünite ve Ders İlişkileri

### 10.1 Hiyerarşi

**Kurs → Ünite → Ders → Öğrenme adımları → Egzersizler**

- **Kurs:** Geniş öğrenme amacı ve yeterlilik çıktısı taşır. MVP'de yalnızca Python Başlangıç kursu vardır.
- **Ünite:** Birbiriyle ilişkili kavramları ve bir ünite sonu yeterliliğini kapsar.
- **Ders:** Tek bir ana öğrenme hedefini 5-10 dakikada öğretir.
- **Öğrenme adımı:** Kısa açıklama, örnek, yönlendirilmiş pratik veya değerlendirme parçasıdır.
- **Egzersiz:** Belirli bir kazanımı ölçen ve deterministik olarak değerlendirilen etkileşimdir.

### 10.2 Ders tasarım standardı

Her ders:

- Tek bir ana öğrenme hedefi taşır.
- En fazla 1-2 yeni kavram tanıtır.
- Ön koşul konuları açıkça tanımlar.
- 5 temel egzersiz içerir.
- En az bir önceki konuyu hatırlama egzersizi içerebilir.
- Yanlış cevaplar için açıklama ve hata etiketi sağlar.
- Tahmini 5-10 dakika sürer.

### 10.3 MVP Python Başlangıç kurs planı

MVP toplamı: **6 ünite, 30 ders, 150 egzersiz ve 3 mini proje**.

| Ünite | Dersler | Temel öğrenme çıktıları | Mini proje |
|---|---:|---|---|
| 1. Python ile Tanışma | 5 | Değer, `print`, metin, sayı, basit çıktı okuma | Yok |
| 2. Değişkenler ve Veri Türleri | 5 | Değişken atama, isimlendirme, `str`, `int`, `float`, dönüşüm | Profil Kartı |
| 3. İşlemler ve Kullanıcı Girdisi | 5 | Aritmetik, işlem önceliği, `input`, basit hesaplama | Yok |
| 4. Kararlar | 5 | Karşılaştırmalar, Boolean mantığı, `if`, `elif`, `else` | Akıllı Karar Asistanı |
| 5. Döngüler | 5 | Tekrar mantığı, `for`, `range`, temel `while`, sayaç | Yok |
| 6. Listeler ve Fonksiyonlara Giriş | 5 | Liste okuma, indeks, temel liste işlemleri, fonksiyon çağırma ve basit tanımlama | Mini Görev Takipçisi |

### 10.4 Ders dağılımı

Her ünitede 5 ders, her derste 5 egzersiz bulunur. Böylece ana ders akışı toplam 150 egzersiz içerir. Mini projeler, bu 150 egzersizin dışında çok adımlı bütünleştirici etkinliklerdir.

## 11. Öğrenme Tasarımı

### 11.1 Pedagojik yaklaşım

Codara aşağıdaki öğrenme bilimi ilkelerini kullanır:

- **Parçalama:** Karmaşık beceriler küçük ve yönetilebilir öğrenme hedeflerine ayrılır.
- **Aktif hatırlama:** Kullanıcı, açıklamayı yeniden okumadan önce cevabı üretmeye teşvik edilir.
- **Aralıklı tekrar:** Zayıf veya unutulma riski bulunan konular zaman içinde yeniden sorulur.
- **Karışık pratik:** İlerleyen aşamalarda farklı konu türleri aynı oturumda birlikte kullanılır.
- **Anında açıklayıcı geri bildirim:** Yanlışın yalnızca sonucu değil, olası nedeni açıklanır.
- **Kademeli destek azaltma:** İlk egzersizlerde yönlendirme fazlayken sonraki egzersizlerde azaltılır.
- **Uygulama ve transfer:** Mini projeler, ayrı ayrı öğrenilen kavramları yeni bir bağlamda birleştirir.

### 11.2 Ders içi zorluk sıralaması

1. Tanıma ve kavramı ayırt etme.
2. Kodun çıktısını tahmin etme.
3. Eksik kodu tamamlama.
4. Hatalı kodu düzeltme.
5. Bir hedef için doğru kod parçalarını oluşturma.

### 11.3 Ustalık yaklaşımı

Bir dersin tamamlanması ile bir konunun ustalaşılması aynı şey değildir.

- **Tamamlanma:** Kullanıcı dersin sonuna ulaşmış ve minimum bitirme koşulunu sağlamıştır.
- **Konu güveni:** Son cevapların doğruluğu, yardım kullanımı ve zaman içindeki tekrar performansından türetilir.
- **Ustalık:** Kullanıcı aynı kavramı farklı bağlamlarda ve farklı günlerde başarıyla uygulamıştır.

MVP'de konu güveni basit ve açıklanabilir kurallarla hesaplanır; makine öğrenmesi kullanılmaz.

## 12. Soru ve Egzersiz Türleri

MVP'de tam olarak 5 temel egzersiz türü bulunur:

### 12.1 Tek seçim

Kullanıcı, bir soru veya kod örneği için seçeneklerden tek doğru cevabı seçer.

**Kullanım:** Kavram tanıma, doğru sözdizimini ayırt etme, çıktı seçme.  
**Değerlendirme:** Doğru seçenek kimliğiyle deterministik eşleşme.

### 12.2 Kod çıktısını tahmin etme

Kullanıcı, gösterilen kısa Python kodunun üreteceği çıktıyı seçeneklerden seçer veya kısıtlı bir cevap alanına girer.

**Kullanım:** Kod okuma, değişken takibi, işlem önceliği, koşul ve döngü anlama.  
**Değerlendirme:** Normalize edilmiş beklenen çıktı veya izin verilen cevaplar listesi.

### 12.3 Boşluk doldurma

Kullanıcı, kod içindeki bir veya daha fazla boşluğu izin verilen token seçenekleriyle tamamlar.

**Kullanım:** Sözdizimi, operatör, değişken ve anahtar kelime uygulaması.  
**Değerlendirme:** Beklenen token dizisi ve kabul edilen eşdeğerler.

### 12.4 Kod bloklarını sıralama

Kullanıcı, verilen kod satırlarını veya mantıksal adımları doğru sıraya getirir. Girintileme, blokların görsel yapısıyla temsil edilir.

**Kullanım:** Algoritmik sıra, koşul ve döngü akışı, fonksiyon yapısı.  
**Değerlendirme:** Beklenen blok kimliği sırası.

### 12.5 Hata bulma ve düzeltme

Kullanıcı, hatalı kod parçasındaki sorunlu bölgeyi seçer ve sınırlı düzeltme seçeneklerinden doğru olanı uygular.

**Kullanım:** Yaygın başlangıç hatalarını tanıma ve nedenini anlama.  
**Değerlendirme:** Hata bölgesi kimliği ve doğru düzeltme kimliği.

### 12.6 Egzersiz içerik gereksinimleri

Her egzersiz aşağıdaki verilere sahip olmalıdır:

- Benzersiz ve kalıcı kimlik.
- İçerik sürümü.
- Kurs, ünite ve ders kimliği.
- Öğrenme hedefi ve konu etiketleri.
- Egzersiz türü.
- Zorluk seviyesi.
- Soru metni ve gerekli kod örneği.
- Deterministik doğru cevap tanımı.
- Kabul edilen eşdeğer cevaplar.
- Doğru cevap açıklaması.
- Yanlış seçeneklere özel geri bildirimler.
- Hata sınıflandırma etiketleri.
- Tahmini çözüm süresi.
- Çevrimdışı kullanılabilir içerik verisi.

## 13. Hata Odaklı Tekrar Sistemi

### 13.1 Amaç

Hata Tekrar Alanı, kullanıcının yanlış cevaplarını hedefli ve yönetilebilir tekrar oturumlarına dönüştürür. Amaç yanlışları biriktirmek değil, yanlış anlamaları gidermektir.

### 13.2 Hata kaydı

Her yanlış cevapta aşağıdakiler kaydedilir:

- Egzersiz kimliği ve içerik sürümü.
- İlgili konu etiketleri.
- Hata türü.
- Verilen cevap ve beklenen cevap referansı.
- Deneme sayısı.
- Yardım veya açıklama kullanımı.
- Zaman damgası.
- Çevrimdışı veya çevrimiçi çözüm durumu.

### 13.3 Hata türleri

- Kavram yanılgısı.
- Sözdizimi karışıklığı.
- Kod akışını takip edememe.
- Veri türü karışıklığı.
- Operatör veya işlem önceliği hatası.
- Dikkat hatası.
- Tekrarlayan hata.

### 13.4 Tekrar sıralama mantığı

MVP'de deterministik öncelik kuralları kullanılır:

1. Aynı konuda tekrarlanan yanlışlar.
2. Son 24 saat içinde yanlış yapılan ve henüz düzeltilmeyen kavramlar.
3. Son tekrarında tekrar yanlış yapılan egzersizler.
4. Uzun süredir tekrar edilmeyen düşük güvenli konular.
5. Bir sonraki ders için ön koşul olan zayıf konular.

### 13.5 Tekrar oturumu

- Varsayılan oturum 3-5 egzersiz içerir.
- Mümkün olduğunda aynı sorunun kopyası yerine aynı kavramı ölçen farklı bir egzersiz kullanılır.
- Kullanıcı doğru cevap verdiğinde açıklama kısa tutulur.
- Kullanıcı tekrar yanlış yaptığında daha ayrıntılı açıklama ve yönlendirilmiş örnek gösterilir.
- Hata kaydı tek doğru cevapla hemen silinmez; konu güveni zaman içindeki performansla yükselir.

## 14. Oyunlaştırma Sistemleri

### 14.1 Byte puanı

Byte, öğrenme etkinlikleri sonucunda kazanılan ilerleme puanıdır.

**Kazanım kaynakları:**

- Ders tamamlama.
- Egzersizi doğru çözme.
- Hata tekrar oturumunu tamamlama.
- Günlük görevi tamamlama.
- Mini proje tamamlama.
- Başarım açma.

**Kurallar:**

- Byte satın alınamaz.
- Byte, kullanıcının becerisinin tek göstergesi olarak sunulmaz.
- Aynı kolay egzersizi sınırsız tekrar ederek yüksek Byte kazanımı engellenir.
- İlk denemede doğruluk küçük bir bonus sağlayabilir; yanlış cevap öğrenme ilerlemesini tamamen değersizleştirmez.
- MVP'de Byte harcama ekonomisi bulunmaz; Byte ilerleme ve motivasyon göstergesidir.

### 14.2 Kod Zinciri

Kod Zinciri, kullanıcının seçtiği haftalık hedef doğrultusunda öğrenme etkinliği yaptığı süreklilik göstergesidir.

**Kurallar:**

- Bir günün zincire sayılması için en az bir ders veya hedefli tekrar oturumu tamamlanmalıdır.
- Yalnızca uygulamayı açmak zinciri korumaz.
- Kullanıcının yerel saat dilimi esas alınır.
- Çevrimdışı tamamlanan etkinlik zincire sayılır ve bağlantı geldiğinde eşitlenir.
- Kaçırılan gün kullanıcıyı utandıran dil veya görsellerle sunulmaz.
- MVP'de Sistem Yedeği bulunmaz.

### 14.3 İşlem Gücü

İşlem Gücü, odaklı ders oturumlarını çerçeveleyen hafif bir enerji sistemidir.

**MVP kuralları:**

- Yeni kullanıcı tam İşlem Gücü ile başlar.
- Ders içindeki belirli sayıda yanlış cevap İşlem Gücü azaltabilir.
- İşlem Gücü bittiğinde kullanıcı yeni ana ders başlatamaz.
- Hata Tekrar Alanı, tamamlanmış dersleri inceleme ve kısa açıklamaları okuma enerji olmadan erişilebilir kalır.
- İşlem Gücü zamanla ücretsiz yenilenir.
- Günlük görevlerden sınırlı yenileme kazanılabilir.
- İlk kullanıcı deneyimi enerji nedeniyle kesilmez.
- İşlem Gücü ödeme baskısı oluşturacak biçimde ayarlanmaz.

MVP doğrulaması sırasında İşlem Gücü'nün öğrenmeyi veya geri dönüşü olumsuz etkilediği görülürse sistem Remote Config ile yumuşatılabilmeli veya devre dışı bırakılabilmelidir.

### 14.4 Günlük ve haftalık görevler

**MVP günlük görevleri:**

- Bir ders tamamla.
- Üç egzersizi doğru çöz.
- Bir hata tekrar oturumu tamamla.
- Belirli miktarda Byte kazan.

Kullanıcıya aynı anda en fazla üç günlük görev gösterilir. Görevler, erişilemeyen veya henüz açılmamış içeriği gerektirmez.

**Tam sürüm haftalık görevleri:**

- Haftada belirli sayıda öğrenme günü tamamla.
- Bir üniteyi veya mini projeyi tamamla.
- Belirli konu gruplarında tekrar yap.
- Arkadaşlarla ortak ancak rekabet baskısı düşük hedeflere katıl.

Haftalık görevler MVP dışında tutulur.

### 14.5 Dev Arenası

Dev Arenası, benzer etkinlik seviyesindeki kullanıcıların dönemsel Byte performansını karşılaştıran lig sistemidir.

**Tam sürüm ilkeleri:**

- Ligler kısa dönemler halinde çalışır.
- Eşleştirme, aşırı zaman harcamayı teşvik etmeyecek gruplar oluşturur.
- Yükselme ve düşme dili utandırıcı değildir.
- Ödüller öğrenme avantajı satın aldırmaz.
- Kullanıcı lig görünürlüğünü kapatabilir.

Dev Arenası MVP dışında tutulur.

### 14.6 Başarımlar

Başarımlar, anlamlı öğrenme kilometre taşlarını görünür kılar.

Örnek başarımlar:

- İlk dersini tamamla.
- İlk hatanı başarıyla düzelt.
- İlk üniteyi tamamla.
- Üç farklı günde tekrar yap.
- İlk mini projeyi tamamla.
- Bir konuyu ustalık seviyesine getir.

Başarımlar tam sürüm kapsamındadır ve MVP dışında tutulur.

### 14.7 Arkadaş sistemi

Tam sürüm arkadaş sistemi:

- Kullanıcı adı veya güvenli davet bağlantısıyla arkadaş ekleme.
- Arkadaş ilerlemesini yalnızca izin verilen düzeyde görme.
- Destekleyici hazır tepkiler gönderme.
- Ortak haftalık hedeflere katılma.
- Engelleme, raporlama ve görünürlük kontrolleri.

Serbest metinli sohbet, güvenlik ve moderasyon maliyeti nedeniyle planlanan temel arkadaş sisteminin parçası değildir. Arkadaş sistemi bütünüyle MVP dışında tutulur.

## 15. Bildirim Stratejisi

### 15.1 Amaç

Bildirimler kullanıcıyı uygulamaya baskıyla döndürmek yerine seçtiği öğrenme planını hatırlatır.

### 15.2 MVP yerel bildirimleri

- Kullanıcının seçtiği saatte günlük öğrenme hatırlatıcısı.
- Kod Zinciri günü henüz tamamlanmadıysa, kullanıcının ayrıca izin verdiği tek bir akşam hatırlatıcısı.
- İşlem Gücü tamamen yenilendi bildirimi varsayılan olarak kapalıdır.

### 15.3 Bildirim kuralları

- Bildirim izni, fayda açıklanmadan istenmez.
- Varsayılan bildirim sıklığı günde en fazla birdir.
- Kullanıcı gün, saat ve bildirim türlerini ayrı ayrı yönetebilir.
- Kullanıcı o gün hedefini tamamladıysa ilgili hatırlatıcı iptal edilir.
- Utandırıcı, korkutucu veya kayıp baskısı yaratan metin kullanılmaz.
- Gece saatlerinde bildirim gönderilmez.
- Bildirime dokunulduğunda kullanıcı doğrudan ilgili önerilen derse veya göreve gider.

Cloud Messaging ile uzaktan bildirimler tam sürüm kapsamındadır; MVP'de yalnızca yerel bildirimler kullanılır.

## 16. Ücretsiz ve Premium Özellikler

Premium paketleme MVP sonrasında doğrulanacaktır. MVP'de temel öğrenme deneyiminin ücret duvarı olmadan test edilmesi önerilir.

### 16.1 Ücretsiz sürüm ilkeleri

- Python Başlangıç kursunun temel öğrenme yolu erişilebilir olmalıdır.
- Hata açıklamaları ve temel tekrar sistemi ücret duvarı arkasına konmaz.
- Kod Zinciri, Byte ve günlük görevler ücretsizdir.
- Çevrimdışı içerik için makul temel erişim sağlanır.
- Reklam kullanılacaksa ders veya hata açıklaması sırasında gösterilmez.

### 16.2 Tam sürüm premium adayları

- Genişletilmiş çevrimdışı kurs indirmeleri.
- İleri düzey kişisel öğrenme raporları.
- Ek tekrar paketleri ve konu odaklı pratikler.
- Ek kurslar ve uzmanlık yolları.
- Kozmetik profil ve Nox kişiselleştirmeleri.
- Aile veya öğrenme destekçisi raporları, açık kullanıcı izniyle.
- Reklamsız kullanım.

### 16.3 Premium sınırları

- Doğru cevabın açıklaması ücretli yapılamaz.
- Kod Zinciri kaybı ödeme tehdidi olarak kullanılamaz.
- İşlem Gücü kasıtlı biçimde öğrenmeyi kesip satın almaya zorlayamaz.
- Kullanıcıya daha iyi değerlendirme sonucu veya lig avantajı satılamaz.

## 17. Etik Oyunlaştırma Yaklaşımı

- Kullanıcıya bildirim, sosyal görünürlük ve rekabet üzerinde kontrol verilir.
- Kaybedilen zincirler utandırıcı dil kullanmadan gösterilir.
- Sahte kıtlık, yanıltıcı geri sayım ve gizli olasılık mekanikleri kullanılmaz.
- Harcama, öğrenme başarısı veya değerlendirme sonucuyla karıştırılmaz.
- İşlem Gücü kullanıcıyı öğrenmeden uzaklaştırıyorsa ölçülür ve ayarlanır.
- Çocuk ve genç kullanıcılar için veri minimizasyonu ve uygun gizlilik varsayılanları uygulanır.
- Arkadaşlık ve lig özellikleri isteğe bağlıdır.
- Günlük hedefler gerçekçi ve değiştirilebilirdir.
- Kullanıcı ara verdiğinde dönüş deneyimi destekleyicidir; geçmiş yokluğu cezalandırılmaz.
- Oyunlaştırma metrikleri, öğrenme kazanımlarının önüne geçmez.

## 18. Çevrimdışı İlerleme ve Eşitleme Gereksinimleri

- İndirilen ders açıklamaları ve egzersizler internet olmadan açılabilmelidir.
- Egzersiz değerlendirmesi cihazda deterministik kurallarla yapılmalıdır.
- Ders tamamlanması, Byte, görev ilerlemesi, hata kayıtları ve Kod Zinciri olayları yerel olarak saklanmalıdır.
- Yerel kayıt şeması sürümlü olmalıdır.
- Bağlantı geldiğinde olaylar güvenli ve tekrar uygulanabilir biçimde eşitlenmelidir.
- Aynı olay birden fazla kez gönderildiğinde mükerrer ödül üretmemelidir.
- Cihaz ve sunucu ilerlemesi çatıştığında öğrenme kaybını en aza indiren açık kurallar uygulanmalıdır.
- İçerik sürümü değiştiğinde eski cevap kayıtları anlamlı biçimde korunmalıdır.
- Kullanıcı hesap oluşturmadan misafir olarak ilerleyebilmeli; hesap oluşturduğunda yerel ilerleme güvenli biçimde bağlanmalıdır.

## 19. Analitik Olayları

Analitik veri minimizasyonu ilkesine göre tasarlanır. Serbest kullanıcı metni, hassas veri veya tam cevap içeriği gereksiz yere analitiğe gönderilmez.

### 19.1 Temel olaylar

| Olay | Ne zaman gönderilir | Temel parametreler |
|---|---|---|
| `app_opened` | Uygulama açıldığında | kaynak, çevrimdışı durumu |
| `onboarding_started` | İlk deneyim başladığında | sürüm |
| `onboarding_completed` | İlk deneyim tamamlandığında | amaç, deneyim seviyesi, süre |
| `onboarding_abandoned` | Akış terk edildiğinde | son adım |
| `lesson_started` | Ders başladığında | kurs, ünite, ders, öneri kaynağı |
| `lesson_resumed` | Yarım ders sürdürüldüğünde | ders, geçen süre |
| `lesson_completed` | Ders tamamlandığında | süre, doğruluk, deneme, çevrimdışı durumu |
| `lesson_abandoned` | Ders tamamlanmadan çıkıldığında | ders, son adım, süre |
| `exercise_answered` | Egzersiz yanıtlandığında | egzersiz türü, konu, doğru/yanlış, deneme, süre |
| `exercise_help_viewed` | Yardım veya açıklama açıldığında | egzersiz türü, konu |
| `error_review_started` | Hata tekrar oturumu başladığında | kuyruk boyutu, kaynak |
| `error_review_completed` | Tekrar oturumu tamamlandığında | egzersiz sayısı, doğruluk |
| `project_started` | Mini proje başladığında | proje |
| `project_completed` | Mini proje tamamlandığında | proje, süre, deneme |
| `bytes_earned` | Byte kazanıldığında | miktar, kaynak |
| `code_chain_extended` | Kod Zinciri uzatıldığında | zincir uzunluğu |
| `code_chain_broken` | Zincir koşulu kaçırıldığında | önceki uzunluk |
| `compute_power_changed` | İşlem Gücü değiştiğinde | değişim, neden, kalan |
| `daily_task_completed` | Günlük görev tamamlandığında | görev türü |
| `notification_permission_result` | Bildirim izni sonucu alındığında | izin sonucu, istem adımı |
| `notification_opened` | Yerel bildirim açıldığında | bildirim türü, gecikme |
| `offline_session_started` | Çevrimdışı öğrenme başladığında | içerik sürümü |
| `offline_sync_completed` | Yerel olaylar eşitlendiğinde | olay sayısı, çatışma sayısı |
| `sync_failed` | Eşitleme başarısız olduğunda | hata sınıfı, tekrar sayısı |

### 19.2 Analitik kuralları

- Olay ve parametre isimleri sürümlenir ve veri sözlüğünde tutulur.
- Egzersiz doğru cevabı veya kullanıcının serbest girdisi analitiğe gönderilmez.
- Kullanıcı kimliği analitik sisteminde mümkün olduğunca takma kimlikli tutulur.
- Çocuk ve genç kullanıcılar için geçerli yasal ve platform gereksinimleri uygulanır.
- Ürün deneyi yapılırsa kullanıcı deneyimini bozmayacak ve öğrenme sonucunu önceliklendirecek hipotezler seçilir.

## 20. Başarı Metrikleri

### 20.1 Kuzey yıldızı metriği

**Haftalık Anlamlı Öğrenen Kullanıcı sayısı:** Bir hafta içinde en az iki farklı günde öğrenme etkinliği tamamlayan ve en az bir ders veya hata tekrar oturumunda ölçülebilir ilerleme gösteren kullanıcı sayısı.

Bu metrik yalnızca uygulama açılışını veya geçirilen süreyi değil, anlamlı öğrenme davranışını ölçer.

### 20.2 Birincil ürün metrikleri

- İlk dersi tamamlama oranı.
- Onboarding sonrası ilk 24 saatte ders tamamlama oranı.
- 1., 7. ve 30. gün geri dönüş oranları.
- Haftalık aktif öğrenen başına öğrenme günü sayısı.
- Başlanan derslerin tamamlanma oranı.
- Ortalama ders süresinin 5-10 dakika aralığında kalma oranı.
- Kod Zinciri başlatan ve sürdüren kullanıcı oranı.

### 20.3 Öğrenme metrikleri

- İlk deneme doğruluk oranı.
- Hata tekrarından sonra aynı konuda doğruluk artışı.
- 7 gün sonra konu koruma doğruluğu.
- Ünite sonu değerlendirme başarısı.
- Mini proje tamamlama oranı.
- Yardım kullanımından sonra doğru çözüm oranı.
- Tekrarlayan hata oranındaki azalma.

### 20.4 Kalite ve teknik metrikler

- Çökmesiz kullanıcı ve oturum oranı.
- Uygulama açılış süresi.
- Ders ekranı yükleme süresi.
- Düşük donanımlı cihazlarda kare hızı ve bellek kullanımı.
- Çevrimdışı oturum başarı oranı.
- Eşitleme başarı oranı ve çatışma oranı.
- İçerik veya değerlendirme kaynaklı hatalı cevap bildirimi oranı.

### 20.5 Etik koruma metrikleri

- Bildirimleri kapatma oranı.
- Bildirim sonrası kısa sürede uygulamadan çıkma oranı.
- İşlem Gücü nedeniyle ders başlatamayan kullanıcı oranı.
- İşlem Gücü tükendikten sonra geri dönmeyen kullanıcı oranı.
- Kod Zinciri kaybı sonrası kullanıcı kaybı.
- Premium ekranı sonrası oturum terk oranı.

## 21. MVP Kapsamı

### 21.1 İçerik kapsamı

- Yalnızca Python Başlangıç kursu.
- 6 ünite.
- 30 ders.
- Dersler içinde toplam 150 egzersiz.
- 5 egzersiz türü.
- 3 mini proje.
- Ders ve egzersiz içeriklerinin veri odaklı ve sürümlü yapısı.

### 21.2 Ürün kapsamı

- İlk kullanıcı deneyimi.
- Kod Rotası ve ders kilit açma sistemi.
- Ders oynatma ve deterministik cevap değerlendirme.
- Ders sonuç ve hata açıklama ekranları.
- Hata Tekrar Alanı.
- Byte puanı.
- Kod Zinciri.
- İşlem Gücü.
- Günlük görevler.
- Yerel bildirimler.
- Çevrimdışı ders ve ilerleme desteği.
- Misafir ilerleme ve hesapla güvenli yedekleme için temel altyapı.
- Temel ayarlar, bildirim tercihleri ve veri/gizlilik kontrolleri.
- Temel analitik, çökme raporlama ve uzaktan yapılandırma altyapısı.

### 21.3 MVP kalite gereksinimleri

- Android ve iOS dikey mobil ekran desteği.
- Düşük donanımlı hedef cihazlarda kabul edilebilir performans.
- Kritik öğrenme mantığı için saf C# sınıfları ve EditMode testleri.
- Temel kullanıcı akışları için PlayMode testleri.
- Çevrimdışı kayıt, yeniden başlatma ve eşitleme senaryoları için testler.
- Güvensiz kullanıcı kodunun cihazda veya backend üzerinde çalıştırılmaması.
- Gizli anahtarların istemcide saklanmaması.
- Kullanıcı kayıtlarının sürümlü ve güvenli olması.

## 22. MVP Dışında Tutulan Özellikler

Aşağıdaki özellikler ilk MVP sürümünde yer almayacaktır:

- Python Başlangıç dışındaki kurslar ve ileri Python içeriği.
- Serbest kod editörü, gerçek Python yorumlayıcısı veya kullanıcı kodu çalıştırma.
- Dev Arenası ve bütün lig özellikleri.
- Başarımlar.
- Arkadaş sistemi, sosyal akış, mesajlaşma ve ortak görevler.
- Haftalık görevler.
- Sistem Yedeği veya seri koruma satın alma/kazanma sistemi.
- Premium abonelik ve ödeme altyapısı.
- Byte harcama ekonomisi veya mağaza.
- Nox ve profil için kozmetik kişiselleştirme.
- Cloud Messaging ile uzaktan kampanya bildirimleri.
- Öğretmen, ebeveyn, sınıf ve kurum panelleri.
- Web veya masaüstü istemcileri.
- Kullanıcı tarafından oluşturulan içerik.
- Yapay zeka destekli öğretmen, sohbet veya açık uçlu cevap değerlendirme.
- Makine öğrenmesi tabanlı kişiselleştirme.
- Canlı etkinlikler ve zaman sınırlı rekabetçi etkinlikler.
- Gelişmiş öğrenme raporları ve sertifika sistemi.
- Uygulama içi reklamlar.
- Çoklu dil desteği.

Bu özelliklerin bir kısmı tam sürüm vizyonunda bulunsa da kullanıcı araştırması, öğrenme sonuçları ve MVP metrikleri doğrulanmadan geliştirilmemelidir.

## 23. Tam Sürüm Kapsamı

Tam sürüm, MVP'nin doğrulanmış öğrenme döngüsü üzerine aşağıdaki alanlarda genişleyebilir:

- Ek Python seviyeleri ve farklı programlama dilleri.
- Daha gelişmiş mini projeler ve güvenli, izole değerlendirme yaklaşımları.
- Gelişmiş aralıklı tekrar ve kişiselleştirilmiş öğrenme planı.
- Haftalık görevler.
- Dev Arenası.
- Başarımlar.
- İzin kontrollü arkadaş sistemi ve ortak hedefler.
- Sistem Yedeği.
- Premium abonelik ve etik paketleme.
- Kozmetik kişiselleştirme.
- Uzaktan bildirimler.
- Gelişmiş öğrenme analitiği ve kullanıcı raporları.
- Uygun güvenlik ve gizlilik kontrolleriyle aile veya öğretmen görünümü.
- Ek dil desteği.

Tam sürüm kapsamına alınacak her özellik, öğrenme etkisi, kullanıcı değeri, güvenlik riski, geliştirme maliyeti ve etik oyunlaştırma ilkelerine göre ayrıca değerlendirilir.

## 24. Fonksiyonel Olmayan Gereksinimler

### 24.1 Güvenlik ve gizlilik

- Firebase Authentication güvenli kimlik doğrulama için kullanılır.
- Firestore erişimleri en az yetki ilkesine göre güvenlik kurallarıyla sınırlandırılır.
- Cloud Functions yalnızca güvenilir sunucu işlemleri için kullanılır.
- Gizli anahtarlar istemci uygulamasında tutulmaz.
- Kullanıcı kodu veya güvensiz girdi yürütülmez.
- Kullanıcı verileri yalnızca gerekli amaçlar için ve minimum kapsamda saklanır.
- Hesap silme ve veri silme akışları tam sürümden önce sağlanmalıdır.

### 24.2 Performans

- Uygulama düşük donanımlı mobil cihazlarda akıcı temel navigasyon sağlamalıdır.
- Ders içeriği hafif veri paketleri halinde saklanmalıdır.
- Büyük görsel veya animasyon bağımlılığı olmadan temel ürün kullanılabilmelidir.
- Ağ çağrıları kritik ders akışını gereksiz yere engellememelidir.

### 24.3 Erişilebilirlik ve kullanılabilirlik

- Metinler okunabilir boyutta ve yeterli kontrastta olmalıdır.
- Renk, durum bilgisinin tek taşıyıcısı olmamalıdır.
- Etkileşim alanları mobil erişilebilirlik ölçülerine uygun olmalıdır.
- Kod örnekleri okunabilir monospace yazı tipiyle gösterilmelidir.
- Kritik akışlar ekran okuyucu ve dinamik metin boyutu gereksinimleri dikkate alınarak tasarlanmalıdır.

## 25. MVP Kabul Kriterleri

MVP, aşağıdaki koşullar sağlandığında ürün kapsamı açısından hazır kabul edilir:

- Python Başlangıç kursunda 6 ünite ve 30 ders erişilebilir durumdadır.
- Dersler toplam 150 doğrulanmış egzersiz içerir.
- Beş egzersiz türünün tamamı deterministik olarak değerlendirilir.
- Üç mini proje başlatılabilir ve tamamlanabilir.
- Kod Rotası ön koşullara göre doğru kilit açar.
- Byte, Kod Zinciri, İşlem Gücü ve günlük görevler tanımlı kurallarla çalışır.
- Yanlış cevaplar Hata Tekrar Alanı'na düşer ve tekrar edilebilir.
- İndirilen dersler internet olmadan tamamlanabilir.
- Çevrimdışı ilerleme uygulama yeniden başlatıldığında korunur ve bağlantı geldiğinde mükerrer ödül oluşturmadan eşitlenir.
- Yerel bildirimler kullanıcı tercihine göre zamanlanır ve günlük hedef tamamlandığında gereksiz bildirim iptal edilir.
- Analitik olayları tanımlı veri sözlüğüne uygun gönderilir.
- Kritik akışlarda engelleyici hata veya uyarı bulunmaz.
- EditMode ve PlayMode testleri hedeflenen kapsamda başarılıdır.
- Güvensiz kullanıcı kodu hiçbir ortamda çalıştırılmaz.

## 26. Açık Ürün Kararları

Uygulama öncesinde aşağıdaki kararlar kullanıcı araştırması, prototip testi veya teknik keşifle netleştirilmelidir:

- İlk hedef yaş aralığının ve buna bağlı yasal/gizlilik gereksinimlerinin kesinleştirilmesi.
- İşlem Gücü'nün başlangıç miktarı, yanlış başına etkisi ve yenilenme süresi.
- Ders tamamlama için minimum doğruluk koşulu.
- Byte kazanım değerleri ve tekrarlı etkinliklerde uygulanacak azalan getiri.
- Kod Zinciri'nin takvim günü ve saat dilimi değişikliklerinde davranışı.
- Misafir ilerlemesinin hesapla birleştirilmesinde çatışma kuralları.
- Python kod gösteriminde kullanılacak sınırlı sözdizimi ve kabul edilen eşdeğer cevap kuralları.
- Mini projelerin adım sayısı ve başarı ölçütleri.
- MVP'nin ücretlendirme olmadan mı, sınırlı premium deneyiyle mi yayınlanacağı.

## 27. Faz Sonu Değerlendirmesi

### Bu belge fazında yapılanlar

- Codara'nın hedef kullanıcıları, değer önerisi ve ürün ilkeleri tanımlandı.
- Python Başlangıç kursunun 6 ünite, 30 ders, 150 egzersiz ve 3 mini proje yapısı belirlendi.
- Beş MVP egzersiz türü ve deterministik değerlendirme yaklaşımı tanımlandı.
- Oyunlaştırma, hata tekrarı, çevrimdışı ilerleme, bildirim ve analitik gereksinimleri belirlendi.
- MVP, tam sürüm ve açıkça MVP dışında tutulan özellikler ayrıştırıldı.
- Başarı metrikleri ve MVP kabul kriterleri tanımlandı.

### Manuel Unity Editor işlemleri

Bu faz yalnızca ürün ve öğrenme tasarım belgesi oluşturduğu için Unity Editor işlemi gerekmemektedir.

### Test durumu

Bu fazda kod veya çalıştırılabilir Unity projesi bulunmadığı için EditMode, PlayMode veya Unity Console kontrolleri çalıştırılmamıştır.

