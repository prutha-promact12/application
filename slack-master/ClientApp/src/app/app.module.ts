import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { UsersService } from './services/users.service';
import { MessageService } from './services/message.service';
import { ChatComponent } from './chat/chat.component';
import { ChatserviceService } from './services/chatservice.service';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    ChatComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'home/:sid', component: HomeComponent },
      { path: 'login', component: LoginComponent },
      { path: 'chat', component: ChatComponent },
      { path: 'chat/:sid/:rid', component: ChatComponent },
      { path: '**', component: LoginComponent },
    ])
  ],
  providers: [UsersService, MessageService, ChatserviceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
