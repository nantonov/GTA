import { AuthProvider } from "./components/authorization/AuthProvider";
import AppRouter from "./components/routing/AppRouter";

function App() {
  return (
    <div className="App">
      <AuthProvider>
        <AppRouter />
      </AuthProvider>
    </div>
  );
}

export default App;
