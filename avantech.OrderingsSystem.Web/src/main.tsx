import ReactDOM from "react-dom/client";
import App from "./App";
import { Auth0Provider } from "@auth0/auth0-react";
import "./index.css";

const domain = "dev-1fcdcvn04b0sx1fu.us.auth0.com";
const clientId = "0Ib21USRlxWlCz8LD0AtuoHg1ea21u1M";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <Auth0Provider
    domain={domain}
    clientId={clientId}
    authorizationParams={{    
      redirect_uri: window.location.origin,
      // audience: 'http://localhost:5000', // Value in Identifier field for the API being called.
      //       scope: 'read:products' // Scope that exists for the API being called. You can create these through the Auth0 Management API or through the Auth0 Dashboard in the Permissions view of your API.
    }}
  >
    <App />
  </Auth0Provider>
);
