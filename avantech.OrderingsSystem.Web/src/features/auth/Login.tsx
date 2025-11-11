import React from "react";
import { useAuth0 } from "@auth0/auth0-react";

const Login: React.FC = () => {
  const { loginWithRedirect, logout, isAuthenticated, user, isLoading } = useAuth0();

  if (isLoading) return <div>Loading...</div>;

  return (
    <div>
      {!isAuthenticated ? (
        <button onClick={() => loginWithRedirect()}>Log In</button>
      ) : (
        <div>
          <span>Welcome, {user?.name}</span>
          
        </div>
      )}
    </div>
  );
};

export default Login;