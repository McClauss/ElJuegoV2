using UnityEngine;

public class Movimiento : MonoBehaviour
{

    int cantidadMonedas=0;
    int sangre=100;

    public float speed=2;

    public Transform posEnemigo;//Referencia a Posición de Enemigo para saber proximidad

    Vector3 posInicial;//Guarda posicioon inicial del jugador

    public Animator anim;// Variable para referencia al animator

    public AudioSource audioS;// Se usara para poner play a un sonido
    public AudioClip clipSonido;// Al sonido que se le dara play

    
    public Rigidbody rb;//Para uso de fisica capturando el rigidbody

    void Start()
    {
        posInicial=transform.position;
        rb=GetComponent<Rigidbody>();//para uso de fisicas
        
    }

    
    void Update()
    {
        MovimientoPlayer();
        ChequearDistancia();
        /*Evalua si el jugador cayo del escenario*/
        if(transform.position.y <-10){
            Respawn();
        }
        //numeroRandom=Random.Range(0,20);
        //puerta.transform.position=new Vecor3(numeroRandom,numeroRandom,numeroRandom);
    }
    
    //Función para mover jugador con Teclado (Felchas y AWSD)
    void MovimientoJugador(){
        float hor= Input.GetAxis("Horizontal");//Lee Eje Horizontal
        float ver= Input.GetAxis("Vertical");//Lee Eje Vertical
        
        Vector3 inputPlayer = new Vector3(hor,0,ver);//Para identificar si el jugador se esta moviendo o no - Uso de Animaciones


        //transform.Translate(new Vector3(0,0,ver)*speed*Time.deltaTime);//Para mover el jugador
        //transform.Rotate(0,hor,0); /*Para rotar el jugador*/

        //transform.Translate(new Vector3(hor,0,ver)*speed*Time.deltaTime);//Para mover y rotar al tiempo
        
        transform.Translate(inputPlayer*speed*Time.deltaTime);//Para mover manejando el inputPlayer
        transform.Rotate(0,hor,0);

        /*Para Manejo de Animación Caminar-Detenerse, saber si se esta oprimiendo teclas de movimiento o no*/
        if(inputPlayer == Vector3.zero){
            anim.SetBool("estaCaminando",false);
            
        }else{
            anim.SetBool("estaCaminando",true);
            StartAudioClip(clipSonido);
        }
        
    }

    /*Movimiento con Fisica*/
    void MovimientoPlayer(){
        float hor= Input.GetAxis("Horizontal");//Lee Eje Horizontal
        float ver= Input.GetAxis("Vertical");//Lee Eje Vertical

        Vector3 inputJugador=new Vector3(hor,0,ver);

        rb.AddForce(inputJugador*speed*Time.deltaTime);//Agrega fuerza con el rigidbody asignado
    }

    /*Funcion para Calcular Distancia Contra un Objeto*/
    void ChequearDistancia(){
        float distancia=Vector3.Distance(transform.position,posEnemigo.position);//mide distancia entre posicion vs posicion dos

        if (distancia<3){
            Debug.Log("Enemigo Próximo: "+ distancia);
        }
    }

    /*Metodo para Respawn al Jugador*/
    void Respawn(){
        transform.position=posInicial;
    }

    //Método para manejo de Sonidos
    void StartAudioClip(AudioClip clip){
        audioS.clip=clip;
        audioS.Play();
    }


    //Método Propio de Trigger para el Tema deteccion de Coliciones Ejemplo: Manejo de Monedas

    //Tambien hay OnTriggerStay (Colicion Constante) y OnTriggerExit Colicion al Salir
    void OnTriggerEnter(Collider col){
        
        if(col.transform.gameObject.tag == "Moneda"){
            cantidadMonedas++;
            Debug.Log("He colicionado con una Moneda. "+cantidadMonedas);
            //col.transform.gameObject.SetActive(false);
            Destroy(col.transform.gameObject);
        }

        if(col.transform.gameObject.tag == "Pinchos"){
            cantidadMonedas++;
            Debug.Log("He colicionado con un Pincho. ");
            Respawn();
        }
    }



}
