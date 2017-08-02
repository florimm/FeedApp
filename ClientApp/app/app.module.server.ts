import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.module.shared';
import { AppContainer } from './containers/App/app.container';

@NgModule({
    bootstrap: [AppContainer ],
    imports: [
        ServerModule,
        AppModuleShared
    ]
})
export class AppModule {
}
