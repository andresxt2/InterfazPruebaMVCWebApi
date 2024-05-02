/*function agregarAlCarrito(producto) {
    const memoria = JSON.parse(localStorage.getItem("semestres"));
    console.log(memoria);
    let cuenta = 0;
    if (!memoria) {
        const nuevoProducto = getNuevoProductoParaMemoria(producto); 
        console.log(nuevoProducto.productoID);
        //Solo se puede guardar strings en local strorage
        localStorage.setItem("semestres", JSON.stringify([nuevoProducto]));
        cuenta = 1;
    } else {

        let indiceProducto;
        if (typeof producto === "object" && producto.hasOwnProperty("productoID")) {
            indiceProducto = memoria.findIndex(semestre => semestre.productoID === producto.productoID);
        } else {
            indiceProducto = memoria.findIndex(semestre => semestre.productoID === JSON.parse(producto.getAttribute("data-producto")).productoID);
        }

        

        const nuevaMemoria = memoria;
        
        //Si no lo encuentra al producto 
        if(indiceProducto === -1) {
            nuevaMemoria.push(getNuevoProductoParaMemoria(producto));
            cuenta = 1;
        } else{
            nuevaMemoria[indiceProducto].cantidad++;
            cuenta = nuevaMemoria[indiceProducto].cantidad;
        }

        localStorage.setItem("semestres", JSON.stringify(nuevaMemoria));
    }

    actualizarCarrito();
    return cuenta;

}*/

function agregarAlCarrito(dataProducto) {
    const producto = JSON.parse(dataProducto); // Parsea directamente el string JSON
    const memoria = JSON.parse(localStorage.getItem("semestres"));
    console.log(memoria);
    let cuenta = 0;

    if (!memoria) {
        const nuevoProducto = getNuevoProductoParaMemoria(producto);
        console.log(nuevoProducto.productoID);
        localStorage.setItem("semestres", JSON.stringify([nuevoProducto]));
        cuenta = 1;
    } else {
        let productoParsed = typeof producto === "string" ? JSON.parse(producto) : producto;
        let indiceProducto = memoria.findIndex(semestre => semestre.productoID === productoParsed.productoID);

        if (indiceProducto === -1) {
            const nuevoProducto = getNuevoProductoParaMemoria(productoParsed);
            memoria.push(nuevoProducto);
            cuenta = 1;
        } else {
          //  memoria[indiceProducto].cantidad++;
            cuenta = memoria[indiceProducto].cantidad;
        }

        localStorage.setItem("semestres", JSON.stringify(memoria));
    }

    actualizarCarrito();
    return cuenta;
}


function restarAlCarrito (producto){
    const memoria = JSON.parse(localStorage.getItem("semestres"));
    let cuenta = 0;
    console.log(memoria);
    if (memoria){
        const indiceProducto = memoria.findIndex(semestre => semestre.productoID === producto.productoID);
        if (indiceProducto !== -1) {
            //memoria[indiceProducto].cantidad > 0 ? memoria[indiceProducto].cantidad-=1:null;
            if (memoria[indiceProducto].cantidad === 1){
                memoria.splice(indiceProducto, 1);
            }else{
                //memoria[indiceProducto].cantidad -= 1;
            }
                localStorage.setItem("semestres", JSON.stringify(memoria));
            actualizarCarrito();
            try {
                cuenta = memoria[indiceProducto].cantidad;
            } catch (e) {
                cuenta = 0;                     
            }
            return cuenta;
        }
    }
}



/**Toma un producto le agrega cantidad 1 y lo devuelve */
/**Toma un producto le agrega cantidad 1 y lo devuelve */
function getNuevoProductoParaMemoria(producto) {
    let nuevoProducto;

    // Verifica si 'producto' es un string JSON (que significa que viene del atributo data-producto)
    if (typeof producto === 'string') {
        try {
            nuevoProducto = JSON.parse(producto);
        } catch (e) {
            console.error("Error al parsear el producto:", e);
            return null; // Manejo de error si no es un JSON válido
        }
    } else if (typeof producto === "object" && producto.hasOwnProperty("productoID")) {
        // Si es un objeto y tiene la propiedad 'productoID', es un objeto producto ya formateado
        nuevoProducto = producto;
    } else {
        console.error("Formato de producto no reconocido");
        return null;
    }

    // Asegura que nuevoProducto es un objeto válido antes de añadir 'cantidad'
    if (nuevoProducto) {
        nuevoProducto.cantidad = 1;
        return nuevoProducto;
    }
}

// Ejemplo de llamada en un elemento HTML
// <button onclick="agregarAlCarrito(getNuevoProductoParaMemoria(this.getAttribute('data-producto')))">Agregar al carrito</button>




function actualizarCarrito ()
{
    const memoria = JSON.parse(localStorage.getItem("semestres"));

      /*Utilizando reduce para reducir los elementos de un array a un único valor.
         Este método ejecuta una función proporcionada por el usuario en cada elemento del array y acumula los resultados en un único valor.*/

    if (memoria && memoria.length > 0){
    const cuenta = memoria.reduce((acumulado,elemento) => acumulado + elemento.cantidad, 0 );
    cuentaCarritoElement.innerText = cuenta;
    bc.postMessage ({
        action: "add",
        count: cuenta,
    });

    } else{
        cuentaCarritoElement.innerText = 0;
        bc.postMessage ({
            action: "add",
            count: 0,
        });
    
    }



   /*
    const contador = document.getElementById("nro-productos");
    let c = 0;
    console.log (parseInt(contador.textContent) + " productos");
  
    if (!memoria){
        console.log("NO HAY PRODUCTOS AGREGADOS")
    } else{

        //Forma obsoleta:
        memoria.forEach(element => {
            c+=element.cantidad;
        });

   }
    */
}

/** Reinicia el carrito */
function reiniciarCarrito(){
    localStorage.removeItem("semestres");
    actualizarCarrito();
  }

actualizarCarrito();