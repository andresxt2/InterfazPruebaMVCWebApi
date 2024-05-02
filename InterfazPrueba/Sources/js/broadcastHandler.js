const cuentaCarritoElement = document.getElementById("nro-productos");
const bc = new BroadcastChannel("nro-productos");

bc.onmessage = function (event) {
    if (event.data.action === "add") {
        // Actualizar el contador del carrito
        cuentaCarritoElement.innerText = event.data.count;
        if  (event.data.count > 0) {
        try {
            crearTarjetasProductos();   
        } catch (error) {    
            console.log(error); 
        }
    }
    try {
        revisarMensajeVacio();     // Luego llamar a revisarMensajeVacio
    } catch (error) {
        console.log(error); 
    }
    
    }
};
