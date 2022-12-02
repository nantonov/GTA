import React from 'react';
import { Provider } from 'react-redux';
import AppRouter from './core/components/appRouter/AppRouter';
import store from './core/redux/store';

const App = () => {
  return (
    <div className="App">
      <Provider store={store}>
        <AppRouter />
      </Provider>
    </div>
  );
};

export default App;
