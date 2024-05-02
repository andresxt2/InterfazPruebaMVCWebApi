
const contenedor = document.getElementById('cart-container');
const carritoVacioElement = document.getElementById("carrito-vacio");
const cantidadElement = document.getElementById("cantidad");
const precioElement = document.getElementById("precio");
const totalesContainer = document.getElementById("hidden-section");

function crearTarjetasProductos() {
    contenedor.innerHTML = "";
    const productos = JSON.parse(localStorage.getItem("semestres"));

    if (productos && productos.length > 0) {
        productos.forEach(producto => {
            const newShoe = document.createElement('article');
            newShoe.classList = "col-12";
            newShoe.innerHTML = `
            <section class="container border-bottom border-dark">
                <div class="row justify-content-center align-items-center mb-3 mt-3">
                    <div class="col-12 col-md-6 text-center">
                        <img src="${producto.foto}" alt="" class="imagen">
                    </div>
                    <div class="col-12 col-md-6 text-center mb-3">
                        <span class="text-center fw-bold p-5">${producto.nombre}</span>
                        <span class="text-center fw-bold precio-font p-3">$${producto.precio}</span>
                        <button type="button" class="bg-warning-subtle fw-bold" id="btnreducir">-</button>
                        <span class="p-2" id="cantidad-producto">${producto.cantidad}</span>
                        <button type="button" class="bg-warning-subtle fw-bold" id="btnagregar">+</button>
                    </div>
                </div>
            </section>`;

            contenedor.appendChild(newShoe);

            // Botones + y -
            newShoe.getElementsByTagName("button")[0].addEventListener("click", (e) => {
                const cuentaElement = e.target.parentElement.getElementsByTagName("span")[2];
                cuentaElement.innerText = restarAlCarrito(producto);
                crearTarjetasProductos();
                actualizarTotales();
                revisarMensajeVacio();
            });

            newShoe.getElementsByTagName("button")[1].addEventListener("click", (e) => {
                const cuentaElement = e.target.parentElement.getElementsByTagName("span")[2];
                cuentaElement.innerText = agregarAlCarrito(producto);
                actualizarTotales();
            });
        });
    }
    revisarMensajeVacio();
    actualizarTotales();
}

function actualizarTotales() {
    const productos = JSON.parse(localStorage.getItem("semestres"));
    let cantidad = 0;
    let precio = 0;
    if (productos && productos.length > 0) {
        productos.forEach((producto) => {
            cantidad += producto.cantidad;
            precio += producto.precio * producto.cantidad;
        });
    }
    cantidadElement.innerText = cantidad;
    localStorage.setItem('precio', precio);
    precioElement.innerText = precio;
    if (precio === 0) {
        reiniciarCarrito();
        revisarMensajeVacio();
    }
}

function revisarMensajeVacio() {
    const productos = JSON.parse(localStorage.getItem("semestres"));
    carritoVacioElement.classList.toggle("escondido", productos);
    totalesContainer.classList.toggle("escondido", !(productos && productos.length > 0));
}

document.getElementById("reiniciar").addEventListener("click", () => {
    var resultado = confirm("¿Estás seguro de que deseas remover todos los items del carrito?");
    if (resultado) {
        contenedor.innerHTML = "";
        reiniciarCarrito();
        revisarMensajeVacio();
    }
});

crearTarjetasProductos();










/*const contenedor = document.getElementById('cart-container');
const carritoVacioElement = document.getElementById("carrito-vacio");
const cantidadElement = document.getElementById("cantidad");
const precioElement = document.getElementById("precio");
const totalesContainer = document.getElementById("hidden-section");
*/
/*
      Formato:     
      <article class="col-12 col-sm-6 col-md-4 col-lg-3 col-xl-2">
        <div class = "d-flex flex-column  border border-dark rounded-4 align-items-center"> 
            <span  class = "text-center fw-bold mt-2"> ZAPATO 1</span>
            <img src="https://andrestayupanta.neocities.org/proyecto/imagenes/img_shoes1.png" alt = "" class = "img-fluid mt-2">
            <span class= "text-center fw-bold precio-font "> $15.00</span>
            <button class="bg-dark rounded-2 text-white mt-2 mb-3 w-75 text-center">Agregar al carrito</button>
        </div>
    </article>
*/ 
/*
function crearTarjetasProductos (){
   contenedor.innerHTML = ""
    const productos = JSON.parse(localStorage.getItem("semestres"));

    if(productos && productos.length>0){
    productos.forEach(producto => {
        const newShoe = document.createElement('article');
        newShoe.classList = "col-12";
        newShoe.innerHTML =  `

        <section class="container border-bottom border-dark">
              <div class="row justify-content-center align-items-center mb-3 mt-3">
                  <div class="col-12 col-md-6 text-center">
                      <img src="${producto.foto}" alt="" class="imagen">
                  </div>
                  <div class="col-12 col-md-6 text-center mb-3">
                      <span class="text-center fw-bold p-5">${producto.nombre}</span>
                      <span class="text-center fw-bold precio-font p-3">$${producto.precio}</span>
                      <button type="button" class="bg-warning-subtle fw-bold" id="btnreducir">-</button>
                      <span class="p-2" id = "cantidad-producto">${producto.cantidad}</span>
                      <button type="button" class="bg-warning-subtle fw-bold" id="btnagregar">+</button>
                  </div>
              </div>
          </section>
    `;

    contenedor.appendChild(newShoe);


    //BOTONES + Y -
    
    newShoe.getElementsByTagName("button")[0].addEventListener("click", (e) => {
        const cuentaElement = e.target.parentElement.getElementsByTagName("span")[2];
        cuentaElement.innerText = restarAlCarrito(producto);
        crearTarjetasProductos();
        actualizarTotales();
        revisarMensajeVacio();     // Luego llamar a revisarMensajeVacio
    });

    newShoe.getElementsByTagName("button")[1]
    .addEventListener("click", (e) => {
        const cuentaElement = e.target.parentElement.getElementsByTagName("span")[2];
        cuentaElement.innerText = agregarAlCarrito(producto);
        actualizarTotales();
    });


    });
}
revisarMensajeVacio();
actualizarTotales();
}
*/
/** Actualiza el total de precio y unidades de la página del carrito */
/** Actualiza el total de precio y unidades de la página del carrito */


/*
function actualizarTotales() {
  const productos = JSON.parse(localStorage.getItem("semestres"));
  let cantidad = 0;
  let precio = 0;
  if (productos && productos.length > 0) {
    productos.forEach((producto) => {
      cantidad += producto.cantidad;
      precio += producto.precio * producto.cantidad;
    });
  }
  cantidadElement.innerText = cantidad;
  localStorage.setItem('precio', precio);
  precioElement.innerText = precio;
  if(precio === 0) {
    reiniciarCarrito();
    revisarMensajeVacio();
  }
}
  
function revisarMensajeVacio (){
    const productos = JSON.parse(localStorage.getItem("semestres"));
    console.log(productos, productos === true);
    carritoVacioElement.classList.toggle("escondido", productos);
    totalesContainer.classList.toggle("escondido", !(productos && productos.length > 0));
}

document.getElementById("reiniciar").addEventListener("click", () => {

    var resultado = confirm("¿Estás seguro de que deseas remover todos los items del carrito?");
    console.log(resultado);
    if (resultado) {
      contenedor.innerHTML = "";
      reiniciarCarrito();
      revisarMensajeVacio();
    }
  });


crearTarjetasProductos();

//PARTE DE COMPRA

*/

/*
document.getElementById("comprar").addEventListener("click", () => {

  const carrito = localStorage.getItem("semestres");
  if (carrito && carrito.length > 0) {
    window.location.href = "http://127.0.0.1:5501/pago.html"; // Reemplaza "URL_DE_TU_PAGINA_DE_PAGO" con la URL real de tu página de pago
   // const res = await fetch("`http://localhost:4000/carrito/comprar`");
  }

});*/



