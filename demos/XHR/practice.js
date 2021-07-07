//Ajax is the traditional way to async HTTP request 
//Create an XHR 
var xhr = new XMLHttpRequest;


//this is a function that is made once we get a response from the server

//but think... where do we want that output to be placed? We can put into the body of our html doc & make the response outputted 
//variable the CONTENT of an html element

//open & send 
xhr.open('POST','https://my-json-server.typicode.com/typicode/demo/comments', true);
xhr.setRequestHeader("Content-type","application/json   ");
xhr.send("id=3&body=filler&postId=1");

//function to print out in console so we can help separate the communication & see where anything may go wrong

xhr.onreadystatechange = () => {
    if (xhr.readyState == 4) {
        if(xhr.status ==200){
            {
                const serverReponse = document.getElementById("serverResponse");
                serverReponse.innerHTML = this.response;//this would make the response go into the html element 
                serverReponse.innerHTML = this.responseText;//I think since objects can technically come in from servers, we should put to text
            }; 
        }
    }
}
