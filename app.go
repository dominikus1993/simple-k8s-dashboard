package main

import (
	"context"
	"errors"
	"fmt"
	"path/filepath"

	v1 "k8s.io/apimachinery/pkg/apis/meta/v1"
	"k8s.io/client-go/kubernetes"
	"k8s.io/client-go/tools/clientcmd"
	"k8s.io/client-go/util/homedir"
)

// App struct
type App struct {
	ctx       context.Context
	clientset *kubernetes.Clientset
}

// NewApp creates a new App application struct
func NewApp() *App {
	config, err := clientcmd.BuildConfigFromFlags("", filepath.Join(homedir.HomeDir(), ".kube", "config"))
	if err != nil {
		panic(err.Error())
	}
	// creates the clientset
	clientset, err := kubernetes.NewForConfig(config)
	if err != nil {
		panic(err.Error())
	}
	return &App{clientset: clientset}
}

// startup is called when the app starts. The context is saved
// so we can call the runtime methods
func (a *App) startup(ctx context.Context) {
	a.ctx = ctx
}

// Greet returns a greeting for the given name
func (a *App) Greet(name string) string {
	return fmt.Sprintf("Hello %s, It's show time!", name)
}

func (a *App) Hello(name string) ([]string, error) {
	namespaces, err := a.clientset.CoreV1().Namespaces().List(a.ctx, v1.ListOptions{})
	if err != nil {
		return nil, err
	}
	result := make([]string, 0)
	for _, res := range namespaces.Items {
		result = append(result, res.Name)
	}
	return result, nil
}

func (a *App) HelloErr(name string) (string, error) {
	return "", errors.New("test")
}
